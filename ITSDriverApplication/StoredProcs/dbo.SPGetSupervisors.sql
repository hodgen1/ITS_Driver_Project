
USE [ITSDriverApp1]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPGetSupervisors]
	
AS
BEGIN

	SET NOCOUNT ON

	SELECT First_Name + ' ' + Last_Name + ' (' + Email + ') - ' + Dept AS NameDeptEmail, Email
	FROM dbo.Supervisor
	ORDER BY NameDeptEmail;	

	RETURN (0)
END