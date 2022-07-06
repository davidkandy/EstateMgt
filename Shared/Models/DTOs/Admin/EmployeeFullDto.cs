using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.DTOs
{
    public class EmployeeFullDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string Photo { get; set; }
        public Guid CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string ReportsTo { get; set; }
        public string MaritalStatus { get; set; }
        public string NextOfKin { get; set; }
        public string NextOfKinEmail { get; set; }
        public string NextOfKinPhone { get; set; }
        public DateTimeOffset? DateOfEmployment { get; set; }
    }
}
