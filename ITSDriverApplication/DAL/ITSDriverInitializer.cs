using System;
using System.Collections.Generic;
using ITSDriverApplication.Models;

namespace ITSDriverApplication.DAL
{
    public class ITSDriverInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ITSDriverContext>
    {
        protected override void Seed(ITSDriverContext context)
        {
            var supervisors = new List<Supervisor>
            {
            new Supervisor{Supervisor_ID=1001,First_Name="Carson",Last_Name="Alexander",Dept="Human Resources",Email="calexander@regis.edu"},
            new Supervisor{Supervisor_ID=1002,First_Name="Meredith",Last_Name="Alonso",Dept="Human Resources",Email="malonso@regis.edu"},
            new Supervisor{Supervisor_ID=1003,First_Name="Arturo",Last_Name="Anand",Dept="Human Resources",Email="aanand@regis.edu"},
            new Supervisor{Supervisor_ID=1004,First_Name="Nino",Last_Name="Olivetto",Dept="Human Resources",Email="nolivetto@regis.edu"}
            };
            supervisors.ForEach(s => context.Supervisors.Add(s));
            context.SaveChanges();

            // EnrollmentDate = DateTime.Parse("2005-09-01")
            var drivers = new List<Driver>
            {
            new Driver{Driver_ID=2001,First_Name="Ben",Last_Name="Peters",Middle_Initial='A',DOB=DateTime.Parse("2005-09-01"),Primary_Phone=8005879777,Email="bpeterso@regis.edu",Driver_Type=Driver_Type.Emp_Required,Driver_Status=Driver_Status.Active,DL_Number="Y789U", DL_State="NY",DL_Exp_Date=DateTime.Parse("2016-09-01"), Ins_Name="State Farm",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2016-09-01"),Supervisor_ID=1001},
            new Driver{Driver_ID=2002,First_Name="Anthony",Last_Name="Jackson",Middle_Initial=' ',DOB=DateTime.Parse("2000-02-02"),Primary_Phone=8005879777,Email="ajacksono@yahoo.com",Driver_Type=Driver_Type.Volunteer,Driver_Status=Driver_Status.Inactive,DL_Number="V789U", DL_State="VI",DL_Exp_Date=DateTime.Parse("2005-09-01"), Ins_Name="Geico",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2005-09-01"),Supervisor_ID=1001},
            new Driver{Driver_ID=2003,First_Name="Jessica",Last_Name="Miller",Middle_Initial='B',DOB=DateTime.Parse("1995-10-22"),Primary_Phone=8005879777,Email="jmiller@regis.edu",Driver_Type=Driver_Type.Emp_Required,Driver_Status=Driver_Status.Active,DL_Number="C789U", DL_State="CO",DL_Exp_Date=DateTime.Parse("2017-09-01"), Ins_Name="Progressive",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2016-09-01"),Supervisor_ID=1002},
            new Driver{Driver_ID=2004,First_Name="Bob",Last_Name="Sacrarich",Middle_Initial='V',DOB=DateTime.Parse("1930-09-11"),Primary_Phone=8005879777,Email="nolivetto@regis.edu",Driver_Type=Driver_Type.Emp_Occasional,Driver_Status=Driver_Status.Active,DL_Number="J789U", DL_State="NJ",DL_Exp_Date=DateTime.Parse("2018-09-01"), Ins_Name="All State",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2016-09-01"),Supervisor_ID=1004},
            new Driver{Driver_ID=2005,First_Name="Mary",Last_Name="Hughley",Middle_Initial=' ',DOB=DateTime.Parse("1970-06-21"),Primary_Phone=8005879777,Email="mhughley@regis.edu",Driver_Type=Driver_Type.Student,Driver_Status=Driver_Status.Active,DL_Number="F789U", DL_State="FL",DL_Exp_Date=DateTime.Parse("2025-09-01"), Ins_Name="Geico",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2015-12-01"),Supervisor_ID=1003}
            };
            drivers.ForEach(s => context.Drivers.Add(s));
            context.SaveChanges();


            var applications = new List<Application>
            {
            new Application{Application_ID=1,Driver_ID=2002,Create_Date=DateTime.Today,Application_Status=Application_Status.Terminated,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Reed",Approver_FName="Abigail",University_Vehicle=false,Rental_Vehicle=true,Personal_Vehicle=false,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet", },
            new Application{Application_ID=2,Driver_ID=2003,Create_Date=DateTime.Today,Application_Status=Application_Status.Open,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Davis",Approver_FName="Shae",University_Vehicle=false,Rental_Vehicle=true,Personal_Vehicle=false,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet", },
            new Application{Application_ID=3,Driver_ID=2004,Create_Date=DateTime.Today,Application_Status=Application_Status.Terminated,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Parsons",Approver_FName="Carl",University_Vehicle=false,Rental_Vehicle=false,Personal_Vehicle=false,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet", },
            new Application{Application_ID=4,Driver_ID=2001,Create_Date=DateTime.Today,Application_Status=Application_Status.Rejected,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Alexander",Approver_FName="Carson",University_Vehicle=false,Rental_Vehicle=true,Personal_Vehicle=true,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet", },
            new Application{Application_ID=5,Driver_ID=2005,Create_Date=DateTime.Today,Application_Status=Application_Status.Approved,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Olivetto",Approver_FName="Nino",University_Vehicle=true,Rental_Vehicle=true,Personal_Vehicle=true,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet", }
            };
            applications.ForEach(s => context.Applications.Add(s));
            context.SaveChanges();
        }
    }
}