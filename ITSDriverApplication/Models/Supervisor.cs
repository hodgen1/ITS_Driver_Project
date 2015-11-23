using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSDriverApplication.Models
{
    public class Supervisor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Supervisor_ID { get; set; }
        [Required]
        public String First_Name { get; set; }
        [Required]
        public String Last_Name { get; set; }
        [Required]
        public String Dept { get; set; }
        [Required]
        public String Email { get; set; }
    }
}