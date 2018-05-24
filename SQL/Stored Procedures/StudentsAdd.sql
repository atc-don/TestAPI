SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Don Sartain
-- Create date: 05/24/2018
-- Description:	Gets Users by StudentID
-- =============================================
CREATE PROCEDURE StudentsAdd
				@StudentFirstName VARCHAR(50),
				@StudentLastName VARCHAR(50)
	
AS
BEGIN	
	SET NOCOUNT ON;

	INSERT INTO 
		dbo.Students
		(
			StudentFirstName,
			StudentLastName
		)
	VALUES
		(
			@StudentFirstName,
			@StudentLastName
		)
    
END
GO
