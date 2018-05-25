/****** Object:  StoredProcedure [dbo].[UsersGetByStudentID]    Script Date: 5/24/2018 3:54:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Gets Students by ID
-- =============================================

declare @procName varchar(100) = '[atcDevAPI].[StudentsGetByID]'

if object_id(@procName) is not null
begin
	drop procedure [atcDevAPI].[StudentsGetByID]
	if object_id(@procName) is not null print '>> Failure: drop procedure '+@procName else print '>> Success: drop procedure '+@procName
end
go

CREATE PROCEDURE [atcDevAPI].[StudentsGetByID]
				@StudentID INT 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 		
		s.StudentID,
		s.StudentFirstName,
		s.StudentLastName,
		sci.StudentContactInfoID,
		sci.StudentEmail,		
		sci.StudentPhone
	FROM
		[atcDevAPI].Students s
	INNER JOIN
		[atcDevAPI].StudentContactInfo sci ON sci.StudentID = s.StudentID
	WHERE
		s.StudentID = @StudentID
    
END
GO


declare @procName varchar(100) = '[atcDevAPI].[StudentsGetByID]'
if object_id(@procName) is null print '>> Failure: create procedure '+@procName else print '>> Success: create procedure '+@procName
go