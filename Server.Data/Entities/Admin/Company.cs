using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Data.Entities.Admin
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed.")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum of 200 characters allowed.")]
        public string Description { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Sector { get; set; }
        public Address Address { get; set; }
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
