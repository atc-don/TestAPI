SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Gets Users by StudentID
-- =============================================
CREATE PROCEDURE UsersGetByID
				@UserID INT 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		u.userID,
		u.StudentID,
		u.UserFirstName,
		u.UserLastName
	FROM
		Users u
	WHERE
		u.UserID = @UserID
    
END
GO
