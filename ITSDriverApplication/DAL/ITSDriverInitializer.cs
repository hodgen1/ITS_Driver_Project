using System;
using System.Collections.Generic;
using ITSDriverApplication.Models;
using System.IO;

namespace ITSDriverApplication.DAL
{
    public class ITSDriverInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ITSDriverContext>
    {
        protected override void Seed(ITSDriverContext context)
        {
            var supervisors = new List<Supervisor>
            {
            new Supervisor{Supervisor_ID="1a16705a-241d-4ff4-99d3-66f9c6fd04d8",First_Name="Meredith",Last_Name="Alonso",Dept="Human Resources",Email="malonso@regis.edu"},
            new Supervisor{Supervisor_ID="7fc81f40-2dc9-4534-8ecc-fd11e429fbc2",First_Name="Arturo",Last_Name="Anand",Dept="Human Resources",Email="aanand@regis.edu"},
            new Supervisor{Supervisor_ID="1dc18009-2654-490c-b72a-7af79377d165",First_Name="Nino",Last_Name="Olivetto",Dept="Human Resources",Email="nolivetto@regis.edu"}
            };
            supervisors.ForEach(s => context.Supervisors.Add(s));
            context.SaveChanges();

            var drivers = new List<Driver>
            {
            new Driver{Driver_ID="1edf5b9b-a9d0-4b26-8921-43a0bab2ddb8",First_Name="Ben",Last_Name="Peters",Middle_Initial="A",DOB=DateTime.Parse("2005-09-01"),Primary_Phone="8005879777",
                Email ="bpeterso@regis.edu",Driver_Type=Driver_Type.Emp_Required,Driver_Status=Driver_Status.Active,DL_Number="Y789U", DL_State="NY",
                DL_Exp_Date =DateTime.Parse("2016-09-01"), Ins_Name="State Farm",Ins_Policy_Number="c7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2016-09-01"),Supervisor_ID="7fc81f40-2dc9-4534-8ecc-fd11e429fbc2"},
            new Driver{Driver_ID="faee1ba2-f20a-4f29-9467-d619b325ef49",First_Name="Anthony",Last_Name="Jackson",Middle_Initial=" ",DOB=DateTime.Parse("2000-02-02"),Primary_Phone="8005879777",
                Email ="ajacksono@yahoo.com",Driver_Type=Driver_Type.Volunteer,Driver_Status=Driver_Status.Inactive,DL_Number="V789U", DL_State="VI",
                DL_Exp_Date =DateTime.Parse("2005-09-01"), Ins_Name="Geico",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2005-09-01"),Supervisor_ID="1dc18009-2654-490c-b72a-7af79377d165"},
            new Driver{Driver_ID="13e5828f-6f40-45d2-8fe7-cbab494cbd47",First_Name="Jessica",Last_Name="Miller",Middle_Initial="B",DOB=DateTime.Parse("1995-10-22"),Primary_Phone="8005879777",
                Email ="jmiller@regis.edu",Driver_Type=Driver_Type.Emp_Required,Driver_Status=Driver_Status.Active,DL_Number="C789U", DL_State="CO",
                DL_Exp_Date =DateTime.Parse("2017-09-01"), Ins_Name="Progressive",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2016-09-01"),Supervisor_ID="1a16705a-241d-4ff4-99d3-66f9c6fd04d8"},
            new Driver{Driver_ID="86631f8c-4bd7-4261-960a-cec03cfdb54c",First_Name="Bob",Last_Name="Sacrarich",Middle_Initial="V",DOB=DateTime.Parse("1930-09-11"),Primary_Phone="8005879777",
                Email ="nolivetto@regis.edu",Driver_Type=Driver_Type.Emp_Occasional,Driver_Status=Driver_Status.Active,DL_Number="J789U", DL_State="NJ",
                DL_Exp_Date =DateTime.Parse("2018-09-01"), Ins_Name="All State",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2016-09-01"),Supervisor_ID="7fc81f40-2dc9-4534-8ecc-fd11e429fbc2"},
            new Driver{Driver_ID="c41710f0-d9fe-43ee-a3a0-803868afaacf",First_Name="Mary",Last_Name="Hughley",Middle_Initial=" ",DOB=DateTime.Parse("1970-06-21"),Primary_Phone="8005879777",
                Email ="mhughley@regis.edu",Driver_Type=Driver_Type.Student,Driver_Status=Driver_Status.Active,DL_Number="F789U", DL_State="FL",
                DL_Exp_Date =DateTime.Parse("2025-09-01"), Ins_Name="Geico",Ins_Policy_Number="7972902h",Ins_Policy_Exp_Date=DateTime.Parse("2015-12-01"),Supervisor_ID="7fc81f40-2dc9-4534-8ecc-fd11e429fbc2"}
            };
            drivers.ForEach(s => context.Drivers.Add(s));
            context.SaveChanges();


            var applications = new List<Application>
            {
            new Application{Application_ID="458dec35-e78e-4eb8-9ea5-f63126b35f61",Driver_ID="faee1ba2-f20a-4f29-9467-d619b325ef49",Create_Date=DateTime.Today,Application_Status=Application_Status.Terminated,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Reed",Approver_FName="Abigail",University_Vehicle=false,Rental_Vehicle=true,Personal_Vehicle=false,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet"},
            new Application{Application_ID="15453e86-3f85-436f-8cc6-015e900b4aac",Driver_ID="13e5828f-6f40-45d2-8fe7-cbab494cbd47",Create_Date=DateTime.Today,Application_Status=Application_Status.Open,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Davis",Approver_FName="Shae",University_Vehicle=false,Rental_Vehicle=true,Personal_Vehicle=false,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet"},
            new Application{Application_ID="432e4484-b2eb-4590-a5c0-000654b84889",Driver_ID="86631f8c-4bd7-4261-960a-cec03cfdb54c",Create_Date=DateTime.Today,Application_Status=Application_Status.Terminated,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Parsons",Approver_FName="Carl",University_Vehicle=false,Rental_Vehicle=false,Personal_Vehicle=false,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet"},
            new Application{Application_ID="ade6fda8-2ca6-4323-a992-4e8e8a17b827",Driver_ID="1edf5b9b-a9d0-4b26-8921-43a0bab2ddb8",Create_Date=DateTime.Today,Application_Status=Application_Status.Rejected,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Alexander",Approver_FName="Carson",University_Vehicle=false,Rental_Vehicle=true,Personal_Vehicle=true,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet"},
            new Application{Application_ID="6d176863-3a45-4699-bdfa-f601af0a6219",Driver_ID="c41710f0-d9fe-43ee-a3a0-803868afaacf",Create_Date=DateTime.Today,Application_Status=Application_Status.Approved,Approval_Date=DateTime.Parse("2015-11-15"),Approval_Duration=3.0,Approval_Exp_Date=DateTime.Parse("2015-11-15"),Approver_LName="Olivetto",Approver_FName="Nino",University_Vehicle=true,Rental_Vehicle=true,Personal_Vehicle=true,Multi_Person_Vehicle=true,Comments="I don't have transportation as yet"}
            };
            applications.ForEach(s => context.Applications.Add(s));
            context.SaveChanges();
        }        
    }
}