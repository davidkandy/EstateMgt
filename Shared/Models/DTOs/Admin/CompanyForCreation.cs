using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class CompanyForCreation
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed.")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Description { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
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
        public string Email { get; set; }
        [Phone]
        public string Phone1 { get; set; }
        [Phone]
        public string Phone2 { get; set; }
        [Url]
        public string Website { get; set; }
        public string Logo { get; set; }
    }
}
