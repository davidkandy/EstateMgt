using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class EmployeeLookupDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public Guid CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
    }
}
