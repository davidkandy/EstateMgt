using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class DepartmentForCreation
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
