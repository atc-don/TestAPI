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
