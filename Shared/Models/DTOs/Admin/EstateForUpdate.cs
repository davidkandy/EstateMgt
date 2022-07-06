using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTOs.Admin
{
    public class EstateForUpdate
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Description { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed.")]
        public string Street { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string City { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed")]
        public string PostalCode { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string State { get; set; }
        public string Geolocation { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }

        //public DateTime StartDate { get; set; }
        //public DateTime DateCompleted { get; set; }
    }
}
