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
        public int Driver_ID { get; set; }
        public int Regis_ID { get; set; }
        [Required]
        public String First_Name { get; set; }
        [Required]
        public String Last_Name { get; set; }
        public char Middle_Initial { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public long Primary_Phone { get; set; }
        public long Alternate_Phone { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public Driver_Type Driver_Type { get; set; }
        [Required]
        public Driver_Status Driver_Status { get; set; }
        [Required]
        public String DL_Number { get; set; }
        [Required]
        public String DL_State { get; set; }
        [Required]
        public DateTime DL_Exp_Date { get; set; }
        [Required]
        public String Ins_Name { get; set; }
        [Required]
        public String Ins_Policy_Number { get; set; }
        [Required]
        public DateTime Ins_Policy_Exp_Date { get; set; }
        [Required]
        public int Supervisor_ID { get; set; }

        public virtual Supervisor Supervisor { get; set; }
    }
}