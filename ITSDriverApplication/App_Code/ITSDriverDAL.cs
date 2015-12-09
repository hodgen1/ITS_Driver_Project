using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ITSDriverApplication.Models;

namespace ITSDriverApplication.App_Code
{
    class ITSDriverDAL
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["ITSDriverContext"].ConnectionString;
        private static SqlCommand Command;
        private static SqlDataAdapter DataAdapter;
        private static DataTable ResultDataTable;

        // Get Supervisors for the drop-down list
        public static DataTable GetSupervisorsForDropDown()
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                Command = new SqlCommand("SpGetSupervisors", conn);
                Command.CommandType = CommandType.StoredProcedure;
                DataAdapter = new SqlDataAdapter(Command);
                ResultDataTable = new DataTable();
                DataAdapter.Fill(ResultDataTable);
                DataAdapter.Dispose();
                Command.Dispose();

                return ResultDataTable;
            }
        }

        // Add Application
        public static bool NewApplication(bool IsUniversityVehicle, bool IsRentalVehicle, bool IsPersonalVehicle, bool IsMultiPersonVehicle, string RegisID, string FirstName, string LastName, string MiddleInitial, DateTime DOB, string PrimaryPhone, string AlternatePhone, 
            string Email, Driver_Type DriverType, Driver_Status DriverStatus, string DLNumber, string DLState, DateTime DLExpDate, string InsName, string InsPolicyNumber, DateTime InsPolicyExpDate,
            string SupervisorEmail)
        {

            using (var db = new ITSDriverContext())
            {
                db.Database.ExecuteSqlCommand(
                    "EXEC SPCreateNewApplication @RegisID,@FirstName,@LastName,@MiddleInitial,@DOB,@PrimaryPhone,@AlternatePhone,@Email,@DriverType,@DriverStatus,@DLNumber,@DLState,@DLExpDate,@InsName,@InsPolicyNumber,@InsPolicyExpDate,@SupervisorEmail,@IsUniversityVehicle,@IsRentalVehicle,@IsPersonalVehicle,@IsMultiPersonVehicle",
                    // Application specific
                    new SqlParameter("@IsUniversityVehicle", IsUniversityVehicle),
                    new SqlParameter("@IsRentalVehicle", IsRentalVehicle),
                    new SqlParameter("@IsPersonalVehicle", IsPersonalVehicle),
                    new SqlParameter("@IsMultiPersonVehicle", IsMultiPersonVehicle),
                    // Driver specific
                    new SqlParameter("@RegisID", RegisID),
                    new SqlParameter("@FirstName", FirstName),
                    new SqlParameter("@LastName", LastName),
                    new SqlParameter("@MiddleInitial", MiddleInitial),
                    new SqlParameter("@DOB", DOB),
                    new SqlParameter("@PrimaryPhone", PrimaryPhone),
                    new SqlParameter("@AlternatePhone", AlternatePhone),
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@DriverType", DriverType),
                    new SqlParameter("@DriverStatus", DriverStatus),
                    new SqlParameter("@DLNumber", DLNumber),
                    new SqlParameter("@DLState", DLState),
                    new SqlParameter("@DLExpDate", DLExpDate),
                    new SqlParameter("@InsName", InsName),
                    new SqlParameter("@InsPolicyNumber", InsPolicyNumber),
                    new SqlParameter("@InsPolicyExpDate", InsPolicyExpDate),
                    new SqlParameter("@SupervisorEmail", SupervisorEmail)
                    );

                return true;
            }
        }
    }
}
