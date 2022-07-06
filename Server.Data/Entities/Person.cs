using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Data.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed.")]
        public string Title { get; set; }
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
        public Address Address { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed.")]
        public string Gender { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; } = DateTimeOffset.Now.AddYears(-30);
        public string Photo { get; set; }
    }
}
