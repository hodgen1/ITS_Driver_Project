using System;
using ITSDriverApplication.Models;
using System.Data;

namespace ITSDriverApplication.App_Code
{
    [System.ComponentModel.DataObject]

    class ITSDriverBLL
    {
        // Get Supervisors for the drop-down list
        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable GetSupervisorsForDropDown()
        {
            return ITSDriverDAL.GetSupervisorsForDropDown();
        }

        // Add Application
        [System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool NewApplication(bool IsUniversityVehicle, bool IsRentalVehicle, bool IsPersonalVehicle, bool IsMultiPersonVehicle, string RegisID, string FirstName, string LastName, string MiddleInitial, DateTime DOB, string PrimaryPhone, string AlternatePhone,
                                string Email, Driver_Type DriverType, Driver_Status DriverStatus, string DLNumber, string DLState, DateTime DLExpDate, string InsName, string InsPolicyNumber, DateTime InsPolicyExpDate,
                                string SupervisorEmail)
        {
            return ITSDriverDAL.NewApplication(IsUniversityVehicle, IsRentalVehicle, IsPersonalVehicle, IsMultiPersonVehicle, RegisID, FirstName, LastName, MiddleInitial, DOB, PrimaryPhone, AlternatePhone,
                                        Email, DriverType, DriverStatus, DLNumber, DLState, DLExpDate, InsName, InsPolicyNumber, InsPolicyExpDate,
                                        SupervisorEmail);
        }
    }
}
