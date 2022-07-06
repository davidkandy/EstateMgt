using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public Guid CompanyId { get; set; }
        public string Company { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int JobId { get; set; }
        public string Job { get; set; }
        public DateTimeOffset? DateOfEmployment { get; set; }
    }
}
