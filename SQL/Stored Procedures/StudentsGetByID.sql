USE [APITest]
GO

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
CREATE PROCEDURE [dbo].[StudentsGetByID]
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
		Students s
	INNER JOIN
		StudentContactInfo sci ON sci.StudentID = s.StudentID
	WHERE
		s.StudentID = @StudentID
    
END
GO


