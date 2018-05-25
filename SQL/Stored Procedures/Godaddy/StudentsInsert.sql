SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Gets Users by StudentID
-- =============================================

declare @procName varchar(100) = '[atcDevAPI].[StudentsInsert]'

if object_id(@procName) is not null
begin
	drop procedure [atcDevAPI].[StudentsInsert]
	if object_id(@procName) is not null print '>> Failure: drop procedure '+@procName else print '>> Success: drop procedure '+@procName
end
go


CREATE PROCEDURE atcDevAPI.StudentsInsert
				@StudentFirstName VARCHAR(50),
				@StudentLastName VARCHAR(50),
				@StudentContactsXML XML
	
AS
BEGIN	
	SET NOCOUNT ON;

	if object_id('tempdb..#StudentContacts') is not null
	begin
		drop table #StudentContacts
	end

	SELECT * INTO #StudentContacts FROM (
		SELECT			
			StudentContactInfo.value('StudentPhone[1]', 'VARCHAR(25)') AS StudentPhone,
			StudentContactInfo.value('StudentEmail[1]', 'VARCHAR(100)') AS StudentEmail
		FROM @StudentContactsXML.nodes('//StudentContacts/StudentContact') AS X(StudentContactInfo)
	) sub	


	INSERT INTO 
		atcDevAPI.Students
		(
			StudentFirstName,
			StudentLastName
		)
	VALUES
		(
			@StudentFirstName,
			@StudentLastName
		)

	INSERT INTO atcDevAPI.StudentContactInfo 
		(
			StudentID, 
			StudentPhone, 
			StudentEmail
		)
	SELECT
		SCOPE_IDENTITY(),
		StudentPhone,
		StudentEmail
	FROM #StudentContacts
    
END
GO

declare @procName varchar(100) = '[atcDevAPI].[StudentsInsert]'
if object_id(@procName) is null print '>> Failure: create procedure '+@procName else print '>> Success: create procedure '+@procName
go