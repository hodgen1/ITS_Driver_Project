using System;
using System.ComponentModel.DataAnnotations;

namespace ITSDriverApplication.Models
{
    public enum Application_Status
    {
        Open, Approved, Rejected, Expired, Terminated
    }

    public class Application
    {
        [Key]
        public int Application_ID { get; set; }
        [Required]
        public int Driver_ID { get; set; }
        [Required]
        public DateTime Create_Date { get; set; } // System Date
        [Required]
        public Application_Status Application_Status { get; set; }
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