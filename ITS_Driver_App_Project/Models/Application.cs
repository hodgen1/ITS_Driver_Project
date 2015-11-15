using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITS_Driver_App_Project.Models
{
    public enum Approval_Status
    {
        Open, Accepted, Rejected
    }

    public class Application
    {
        public int Application_ID { get; set; }
        public DateTime Create_Date { get; set; } // System Date
        public Approval_Status? Approval_Status { get; set; }
        public DateTime Approval_Date { get; set; } // System Date
        public double Approval_Duration { get; set; }
        public DateTime Approval_Exp_Date { get; set; }
        public String Approver_LName { get; set; }
        public String Approver_FName { get; set; }
        public bool University_Vehicle { get; set; }
        public bool Rental_Vehicle { get; set; }
        public bool Personal_Vehicle { get; set; }
        public bool Multi_Person_Vehicle { get; set; }
        public String Comments { get; set; }

        public virtual Driver Driver { get; set; }
    }
}