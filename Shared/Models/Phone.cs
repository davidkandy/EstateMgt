using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Name { get; set; }
        [Phone]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Phone { get; set; }
        public bool IsPrimary { get; set; } = false;
        public Guid? OrganizationId { get; set; }
        public Guid? ContactId { get; set; }
    }
}
