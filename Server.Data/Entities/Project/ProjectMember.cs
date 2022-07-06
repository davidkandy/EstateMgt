using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Project
{
    public class ProjectMember
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public virtual Project Project { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Role { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Phone]
        public string Phone2 { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
    }
}
