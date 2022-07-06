using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class EmployeeForCreation
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string LastName { get; set; }
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Phone1 { get; set; }
        [Phone]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Phone2 { get; set; }
        public Guid CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
        public DateTimeOffset? DateOfEmployment { get; set; } = DateTimeOffset.Now;
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
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Street { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string City { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed.")]
        public string PostalCode { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string State { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Country { get; set; } = "Nigeria";
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed.")]
        public string Gender { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; } = DateTimeOffset.Now.AddYears(-30);
        public string Photo { get; set; }
    }
}
