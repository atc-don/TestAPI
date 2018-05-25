SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Add user
-- =============================================

declare @procName varchar(100) = '[atcDevAPI].[UsersInsert]'

-- DROP PROCEDURE UsersInsert

if object_id(@procName) is not null
begin
	drop procedure [atcDevAPI].[UsersInsert]
	if object_id(@procName) is not null print '>> Failure: drop procedure '+@procName else print '>> Success: drop procedure '+@procName
end
go

CREATE PROCEDURE UsersInsert
				@StudentID INT,
				@UserFirstName VARCHAR(50),
				@UserLastName VARCHAR(50),
				@UserContactsXML XML
	
AS
BEGIN	
	SET NOCOUNT ON;

		if object_id('tempdb..#UserContacts') is not null
	begin
		drop table #UserContacts
	end

	SELECT * INTO #UserContacts FROM (
		SELECT			
			UserContactInfo.value('UserPhone[1]', 'VARCHAR(25)') AS UserPhone,
			UserContactInfo.value('UserEmail[1]', 'VARCHAR(100)') AS UserEmail
		FROM @UserContactsXML.nodes('//UserContacts/UserContact') AS X(UserContactInfo)
	) sub	


	INSERT INTO 
		atcDevAPI.Users
		(
			StudentID,
			UserFirstName,
			UserLastName
		)
	VALUES
		(
			@StudentID,
			@UserFirstName,
			@UserLastName
		)    


	INSERT INTO atcDevAPI.UserContactInfo 
		(
			UserID, 
			UserPhone, 
			UserEmail
		)
	SELECT
		SCOPE_IDENTITY(),
		UserPhone,
		UserEmail
	FROM #UserContacts
END
GO

declare @procName varchar(100) = '[atcDevAPI].[UsersInsert]'
if object_id(@procName) is null print '>> Failure: create procedure '+@procName else print '>> Success: create procedure '+@procName
go