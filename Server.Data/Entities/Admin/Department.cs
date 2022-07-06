using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Data.Entities.Admin
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}