-- Author: N. Hodge
-- Create Date: 11/27/2015
-- Description: This procedure creates a new application
--=========================================================================================================================================================================================

CREATE PROCEDURE [dbo].[SpNewApplication]
	@IsUniversityVehicle bit,
	@IsRentalVehicle bit,
	@IsPersonalVehicle bit,
	@IsMultiPersonVehicle bit,

	-- Driver specific parameters
	@RegisID nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@MiddleInitial char,
	@DOB DateTime,
	@PrimaryPhone nvarchar(20),
	@AlternatePhone nvarchar(20),
	@Email nvarchar(50),
	@DriverType nvarchar(15),
	@DriverStatus nvarchar(15),
	@DLNumber nvarchar (50),
	@DLState nvarchar(2),
	@DLExpDate DateTime,
	@InsName nvarchar(100),
	@InsPolicyExpDate DateTime,
	@SupervisorEmail nvarchar(50)
		
AS
BEGIN

SET NOCOUNT ON

	DECLARE
	@SupervisorID uniqueidentifier = (SELECT Supervisor_ID FROM Supervisor WHERE Email = @SupervisorEmail), -- This should not be null. Supervisor must exist before the user submits an application. If supervisor doesn't exist, throw error.
	@ApplicationID uniqueidentifier = NEWID(),
	@DriverID uniqueidentifier;

	BEGIN TRANSACTION

	--=========================================================================================================================================================================================
-- GET DRIVER


	-- Check to see if the driver exists already
	SET @DriverID = (SELECT d.Driver_ID FROM Driver d WHERE @DLNumber = d.DL_Number);

	-- If driver doesn't exist, create new driver
	IF @DriverID IS NULL
		BEGIN
			SET @DriverID = NEWID(); 
			EXEC SpCreateDriver @DriverID,@RegisID,@FirstName, @LastName, @MiddleInitial, @DOB, @PrimaryPhone, @AlternatePhone, 
			@Email, @DriverType, @DriverStatus, @DLNumber, @DLState, @DLExpDate, @InsName, @InsPolicyExpDate, @SupervisorID
		END

--=========================================================================================================================================================================================
-- CREATE NEW APPLICATION


	INSERT INTO Application (Application_ID, Driver_ID, Create_Date, Application_Status, University_Vehicle, Rental_Vehicle, Personal_Vehicle, Multi_Person_Vehicle)	
	VALUES (@ApplicationID, @DriverID, CURRENT_TIMESTAMP, 1, @IsUniversityVehicle, @IsRentalVehicle, @IsPersonalVehicle, @IsMultiPersonVehicle)


	COMMIT TRANSACTION
	RETURN (0)

END