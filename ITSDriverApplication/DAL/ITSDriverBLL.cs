using System;
using ITSDriverApplication.Models;

namespace ITSDriverApplication.DAL
{
    [System.ComponentModel.DataObject]

    class ITSDriverBLL
    {
        [System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Insert, true)]
        public String NewApplication(bool IsUniversityVehicle, bool IsRentalVehicle, bool IsPersonalVehicle, bool IsMultiPersonVehicle, string RegisID, string FirstName, string LastName, string MiddleInitial, DateTime DOB, string PrimaryPhone, string AlternatePhone,
                                string Email, Driver_Type DriverType, Driver_Status DriverStatus, string DLNumber, string DLState, DateTime DLExpDate, string InsName, string InsPolicyNumber, DateTime InsPolicyExpDate,
                                string SupervisorEmail)
        {
            return ITSDriverDAL.NewApplication(IsUniversityVehicle, IsRentalVehicle, IsPersonalVehicle, IsMultiPersonVehicle, RegisID, FirstName, LastName, MiddleInitial, DOB, PrimaryPhone, AlternatePhone,
                                        Email, DriverType, DriverStatus, DLNumber, DLState, DLExpDate, InsName, InsPolicyNumber, InsPolicyExpDate,
                                        SupervisorEmail);
        }
    }
}
