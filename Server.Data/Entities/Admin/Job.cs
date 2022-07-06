using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Entities.Admin
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Responsibilities { get; set; }
    }
}
