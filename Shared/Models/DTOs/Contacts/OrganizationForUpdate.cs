using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class OrganizationForUpdate
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed.")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Description { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Sector { get; set; }
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
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string PrimaryEmailAddress { get; set; }
        [Phone]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string PrimaryPhoneNumber { get; set; }
        [Url]
        public string Website { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Facebook { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Twitter { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Instagram { get; set; }

        //public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        //public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
