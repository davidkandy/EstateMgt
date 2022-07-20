using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.CoreEntities
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string JobPosition { get; set; }

        public string? JobDescription { get; set; }
    }
}