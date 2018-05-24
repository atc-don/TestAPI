SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Add user
-- =============================================
CREATE PROCEDURE UsersAdd
				@StudentID INT,
				@UserFirstName VARCHAR(50),
				@UserLastName VARCHAR(50)
	
AS
BEGIN	
	SET NOCOUNT ON;

	INSERT INTO 
		dbo.Users
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
    
END
GO
