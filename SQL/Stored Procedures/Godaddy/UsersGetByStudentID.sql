SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Gets Users by StudentID
-- =============================================

-- DROP PROCEDURE UsersGetByStudentID

declare @procName varchar(100) = '[atcDevAPI].[UsersGetByStudentID]'

-- DROP PROCEDURE UsersInsert

if object_id(@procName) is not null
begin
	drop procedure [atcDevAPI].[UsersGetByStudentID]
	if object_id(@procName) is not null print '>> Failure: drop procedure '+@procName else print '>> Success: drop procedure '+@procName
end
go

CREATE PROCEDURE UsersGetByStudentID
				@StudentID INT 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		u.UserID,
		u.StudentID,
		u.UserFirstName,
		u.UserLastName,
		uci.UserContactInfoID,
		uci.UserEmail,
		uci.UserPhone
	FROM
		Users u
	INNER JOIN
		UserContactInfo uci ON uci.UserID = u.UserID
	WHERE
		u.StudentID = @StudentID
    
END
GO

declare @procName varchar(100) = '[atcDevAPI].[UsersGetByStudentID]'
if object_id(@procName) is null print '>> Failure: create procedure '+@procName else print '>> Success: create procedure '+@procName
go