using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class JobForCreation
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Responsibilities { get; set; }
    }
}
