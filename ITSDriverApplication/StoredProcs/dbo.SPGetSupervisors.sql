
CREATE PROCEDURE [dbo].[SPGetSupervisors]

	
AS
BEGIN

	SET NOCOUNT ON

	
	--=========================================================================================================================================================================================
-- CREATE/UPDATE DRIVER
	SELECT First_Name + ' ' + Last_Name + ' (' + Email + ') - ' + Dept AS NameDeptEmail, Email
	FROM dbo.Supervisor
	ORDER BY NameDeptEmail;
	
	

	RETURN (0)
END