using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTOs.Admin
{
    public class EstateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Geolocation { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }

        //public DateOnly StartDate { get; set; }
        //public DateOnly DateCompleted { get; set; }
    }
}
