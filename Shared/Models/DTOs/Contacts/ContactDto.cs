using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid OrganizationId { get; set; }
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
