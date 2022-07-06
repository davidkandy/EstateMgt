using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class ContactForCreation
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
        public Guid? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string JobTitle { get; set; }
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string PrimaryEmailAddress { get; set; }
        [Phone]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string PrimaryPhoneNumber { get; set; }
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
    }
}
