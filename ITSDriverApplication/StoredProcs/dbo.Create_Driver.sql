-- Author: N. Hodge
-- Create Date: 11/27/2015
-- Description: This procedure creates a new driver
--=========================================================================================================================================================================================

CREATE PROCEDURE [dbo].[SpCreateDriver]
	@DriverID uniqueidentifier,
	@RegisID nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@MiddleInitial char,
	@DOB DateTime,
	@PrimaryPhone nvarchar(20),
	@AlternatePhone nvarchar(20),
	@Email nvarchar,
	@DriverType nvarchar,
	@DriverStatus nvarchar,
	@DLNumber nvarchar,
	@DLState nvarchar,
	@DLExpDate DateTime,
	@InsName nvarchar,
	@InsPolicyExpDate DateTime,
	@SupervisorID uniqueidentifier

	
AS
BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION
	--=========================================================================================================================================================================================
-- CREATE DRIVER

	IF (@SupervisorID <> NULL)
		BEGIN		
			INSERT INTO dbo.Driver (Driver_ID, Regis_ID, First_Name, Last_Name, Middle_Initial, DOB, Primary_Phone, Alternate_Phone, Email, Driver_Type, Driver_Status, DL_Number, DL_State, DL_Exp_Date, Ins_Name, Ins_Policy_Exp_Date, Supervisor_ID)	
			VALUES (@DriverID, @RegisID, @FirstName, @LastName, @MiddleInitial, @DOB, @PrimaryPhone, @AlternatePhone, @Email, @DriverType, @DriverStatus, @DLNumber, @DLState, @DLExpDate, @InsName, @InsPolicyExpDate, @SupervisorID)

			IF(@@error <> 0)
			BEGIN
				ROLLBACK TRANSACTION
				RETURN (1)
			END
		END
	ELSE
		BEGIN
			RETURN (1)
		END
	
	
	COMMIT TRANSACTION
	RETURN (0)
END