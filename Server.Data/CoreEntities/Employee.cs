using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.CoreEntities
{
    public class Employee
    {
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone1 { get; set; }

        [Required]
        public string NextOfKin { get; set; }

        [Phone]
        public string NextOfKinPhone { get; set; }

        [EmailAddress]
        public string NextOfKinEmail { get; set; }


        public DateTimeOffset? DateOfEmployment { get; set; }
    }
}