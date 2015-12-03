USE [ITSDriverApp1]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPCreateNewApplication]

	-- Driver specific parameters
	@RegisID nvarchar(20),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@MiddleInitial char,
	@DOB DateTime,
	@PrimaryPhone nvarchar(20),
	@AlternatePhone nvarchar(20),
	@Email nvarchar(50),
	@DriverType int,
	@DriverStatus int,
	@DLNumber nvarchar (50),
	@DLState nvarchar(2),
	@DLExpDate DateTime,
	@InsName nvarchar(100),
	@InsPolicyNumber nvarchar(100),
	@InsPolicyExpDate DateTime,
	@SupervisorEmail nvarchar(50),
	--@SupervisorID uniqueidentifier
	
	-- Application specific parameters	
	@IsUniversityVehicle bit,
	@IsRentalVehicle bit,
	@IsPersonalVehicle bit,
	@IsMultiPersonVehicle bit

	
AS
BEGIN

	SET NOCOUNT ON

	
	--=========================================================================================================================================================================================
-- CREATE/UPDATE DRIVER
	BEGIN TRANSACTION
	
	-- Create temp table
	CREATE TABLE #DriverTemp(
	Driver_ID NVARCHAR (128) NOT NULL,
	DL_Number NVARCHAR (50) NOT NULL
	);

		IF (@DLNumber IN (SELECT DL_Number FROM dbo.Driver))
			BEGIN

				INSERT INTO #DriverTemp
				VALUES ((SELECT d.Driver_ID FROM dbo.Driver d WHERE @DLNumber = d.DL_Number), 
					@DLNumber);

				UPDATE dbo.Driver
				SET Regis_ID = @RegisID,
					First_Name = @FirstName,
					Last_Name = @LastName,
					Middle_Initial = @MiddleInitial,
					DOB = @DOB,
					Primary_Phone = @PrimaryPhone,
					Alternate_Phone = @AlternatePhone, 
					Email = @Email, 
					DL_State = @DLState, 
					DL_Exp_Date = @DLExpDate, 
					Ins_Name = @InsName, 
					Ins_Policy_Number = @InsPolicyNumber,
					Ins_Policy_Exp_Date = @InsPolicyExpDate, 
					Supervisor_ID = (SELECT Supervisor_ID FROM dbo.Supervisor WHERE Email = @SupervisorEmail)

				WHERE DL_Number = @DLNumber
			END

		ELSE
			BEGIN	
				INSERT INTO #DriverTemp
				VALUES (NEWID(), @DLNumber);
				
				INSERT INTO dbo.Driver (Driver_ID, Regis_ID, First_Name, Last_Name, Middle_Initial, DOB, 
					Primary_Phone, Alternate_Phone, Email, Driver_Type, Driver_Status, DL_Number, DL_State, 
					DL_Exp_Date, Ins_Name, Ins_Policy_Number, Ins_Policy_Exp_Date, Supervisor_ID)	
				VALUES ((SELECT Driver_ID FROM #DriverTemp), @RegisID, @FirstName, @LastName, @MiddleInitial, @DOB, 
					@PrimaryPhone, @AlternatePhone, @Email, @DriverType, @DriverStatus, @DLNumber, @DLState, 
					@DLExpDate, @InsName, @InsPolicyNumber, @InsPolicyExpDate, 
					(SELECT Supervisor_ID FROM dbo.Supervisor WHERE Email = @SupervisorEmail))

				IF(@@error <> 0)
				BEGIN
					ROLLBACK TRANSACTION
					RETURN (1)
				END
			END
	COMMIT TRANSACTION
	
	
	-- Create the application
	BEGIN TRANSACTION
	INSERT INTO Application (Application_ID, Driver_ID, Create_Date, Application_Status,
			 University_Vehicle, Rental_Vehicle, Personal_Vehicle, Multi_Person_Vehicle)	
		VALUES (NEWID(), (SELECT d.Driver_ID FROM #DriverTemp d WHERE @DLNumber = d.DL_Number), 
			CURRENT_TIMESTAMP, 1, @IsUniversityVehicle, @IsRentalVehicle, @IsPersonalVehicle, 
			@IsMultiPersonVehicle)
	
	COMMIT TRANSACTION

	DROP TABLE #DriverTemp;

	RETURN (0)
END