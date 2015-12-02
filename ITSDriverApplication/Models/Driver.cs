using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSDriverApplication.Models
{
    public enum Driver_Type
    {
        Emp_Occasional, Emp_Required, Student, Volunteer
    }

    public enum Driver_Status
    {
        Active, Inactive
    }

    public class Driver
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Driver_ID { get; set; }
        public string Regis_ID { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        public string Middle_Initial { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string Primary_Phone { get; set; }
        public string Alternate_Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Driver_Type Driver_Type { get; set; }
        [Required]
        public Driver_Status Driver_Status { get; set; }
        [Required]
        public string DL_Number { get; set; }
        [Required]
        public string DL_State { get; set; }
        [Required]
        public DateTime DL_Exp_Date { get; set; }
        [Required]
        public string Ins_Name { get; set; }
        [Required]
        public string Ins_Policy_Number { get; set; }
        [Required]
        public DateTime Ins_Policy_Exp_Date { get; set; }
        [Required]
        public string Supervisor_ID { get; set; }

        public virtual Supervisor Supervisor { get; set; }
    }
}