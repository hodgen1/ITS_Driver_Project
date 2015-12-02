using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ITSDriverApplication.Models;

namespace ITSDriverApplication.DAL
{
    class ITSDriverDAL
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["ITSDriverContext"].ConnectionString;
        private static SqlCommand Command;

        public static String NewApplication(bool IsUniversityVehicle, bool IsRentalVehicle, bool IsPersonalVehicle, bool IsMultiPersonVehicle, string RegisID, string FirstName, string LastName, string MiddleInitial, DateTime DOB, string PrimaryPhone, string AlternatePhone, 
            string Email, Driver_Type DriverType, Driver_Status DriverStatus, string DLNumber, string DLState, DateTime DLExpDate, string InsName, DateTime InsPolicyExpDate,
            string SupervisorEmail)
        {

            using (var db = new ITSDriverContext())
            {
                String ApplicationID = "";
                String SupervisorID = "";
                String DriverID = "";

                db.Database.ExecuteSqlCommand(
                    "EXEC SpNewApplication @IsUniversityVehicle,@IsRentalVehicle,@IsPersonalVehicle, @IsMultiPersonVehicle, @RegisID, @FirstName, @LastName, @MiddleInitial, @DOB, @PrimaryPhone, @AlternatePhone, @Email, @DriverType, @DriverStatus, @DLNumber, @DLState, @DLExpDate, @InsName, @InsPolicyExpDate, @SupervisorEmail",
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
                    new SqlParameter("@InsPolicyExpDate", InsPolicyExpDate),
                    new SqlParameter("@SupervisorEmail", SupervisorEmail)
                    );

                ApplicationID = Command.ExecuteScalar().ToString();
                SupervisorID = Command.ExecuteScalar().ToString();
                DriverID = Command.ExecuteScalar().ToString();

                return ApplicationID;
            }















            //using (SqlConnection conn = new SqlConnection(ConnString))
            //{
            //    String ApplicationID = "";
            //    String SupervisorID = "";
            //    String DriverID = "";

            //    //Guid SupervisorID = new Guid();
            //    //Guid DriverID = new Guid();
            //    //Guid AppID = new Guid();

            //    conn.Open();
            //    SqlTransaction aTransaction = conn.BeginTransaction();

            //try
            //{
            //    Command = new SqlCommand("SpNewApplication", conn, aTransaction);
            //    Command.CommandType = CommandType.StoredProcedure;

            //    // Application specific
            //    Command.Parameters.Add("@IsUniversityVehicle", SqlDbType.Bit).Value = IsUniversityVehicle;
            //    Command.Parameters.Add("@IsRentalVehicle", SqlDbType.Bit).Value = IsRentalVehicle;
            //    Command.Parameters.Add("@IsPersonalVehicle", SqlDbType.Bit).Value = IsPersonalVehicle;
            //    Command.Parameters.Add("@IsMultiPersonVehicle", SqlDbType.Bit).Value = IsMultiPersonVehicle;

            //    // Driver specific
            //    Command.Parameters.Add("@RegisID", SqlDbType.NVarChar).Value = RegisID;
            //    Command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            //    Command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            //    Command.Parameters.Add("@MiddleInitial", SqlDbType.Char).Value = MiddleInitial;
            //    Command.Parameters.Add("@DOB", SqlDbType.DateTime).Value = DOB;
            //    Command.Parameters.Add("@PrimaryPhone", SqlDbType.NVarChar).Value = PrimaryPhone;
            //    Command.Parameters.Add("@AlternatePhone", SqlDbType.NVarChar).Value = AlternatePhone;
            //    Command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
            //    Command.Parameters.Add("@DriverType", SqlDbType.NVarChar).Value = DriverType;
            //    Command.Parameters.Add("@DriverStatus", SqlDbType.NVarChar).Value = DriverStatus;
            //    Command.Parameters.Add("@DLNumber", SqlDbType.NVarChar).Value = DLNumber;
            //    Command.Parameters.Add("@DLState", SqlDbType.NVarChar).Value = DLState;
            //    Command.Parameters.Add("@DLExpDate", SqlDbType.DateTime).Value = DLExpDate;
            //    Command.Parameters.Add("@InsName", SqlDbType.NVarChar).Value = InsName;
            //    Command.Parameters.Add("@InsPolicyExpDate", SqlDbType.DateTime).Value = InsPolicyExpDate;
            //    Command.Parameters.Add("@SupervisorEmail", SqlDbType.NVarChar).Value = SupervisorEmail;

            //    //Command.Parameters.Add("@SupervisorID", SqlDbType.UniqueIdentifier).Value = SupervisorID;
            //    //Command.Parameters.Add("@ApplicationID", SqlDbType.UniqueIdentifier).Value = AppID;
            //    //Command.Parameters.Add("@DriverID", SqlDbType.UniqueIdentifier).Value = DriverID;

            //    ApplicationID = Command.ExecuteScalar().ToString();
            //    SupervisorID = Command.ExecuteScalar().ToString();
            //    DriverID = Command.ExecuteScalar().ToString();

            //    aTransaction.Commit();
            //}
            //catch (Exception err)
            //{
            //    aTransaction.Rollback();
            //    throw new ApplicationException("Inserting Application Failed. " + err.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //    Command.Dispose();
            //}

            //System.Web.HttpContext.Current.Session["ApplicationID"] = ApplicationID;
            //return ApplicationID;
            //}
        }
    }
}
