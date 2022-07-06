using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Server.Data.Entities.Admin
{
    public class Employee : Person
    {
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed.")]
        public string MaritalStatus { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string NextOfKin { get; set; }
        [EmailAddress]
        public string NextOfKinEmail { get; set; }
        [Phone]
        public string NextOfKinPhone1 { get; set; }
        [Phone]
        public string NextOfKinPhone2 { get; set; }
        public DateTimeOffset? DateOfEmployment { get; set; }
    }
}
