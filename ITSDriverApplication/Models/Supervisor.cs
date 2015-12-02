using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSDriverApplication.Models
{
    public class Supervisor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Supervisor_ID { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Dept { get; set; }
        [Required]
        public string Email { get; set; }
    }
}