using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class OrganizationLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
