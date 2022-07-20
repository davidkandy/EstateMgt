using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Data.Entities
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
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
