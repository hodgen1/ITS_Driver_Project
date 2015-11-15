using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITS_Driver_App_Project.Models
{
    public enum Driver_Type
    {

    }

    public enum Driver_Status
    {

    }

    public class Driver
    {
        public int Driver_ID { get; set; }
        public int Regis_ID { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public char Middle_Initial { get; set; }
        public DateTime DOB { get; set; }
        public int Primary_Phone { get; set; }
        public int Alternate_Phone { get; set; }
        public String Email { get; set; }
        public Driver_Type? Driver_Type { get; set; }
        public Driver_Status? Driver_Status { get; set; }
        public String DL_Number { get; set; }
        public String DL_State { get; set; }
        public DateTime DL_Exp_Date { get; set; }
        public String Ins_Name { get; set; }
        public String Ins_Policy_Number { get; set; }
        public DateTime Ins_Policy_Exp_Date { get; set; }

        public virtual Supervisor Supervisor { get; set; }
    }
}