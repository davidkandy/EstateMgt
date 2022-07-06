using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Estate
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        public string PostalCode { get; set; }

        [Required]
        public string State { get; set; }

        public string Geolocation { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }

        //public DateOnly StartDate { get; set; }
        //public DateOnly DateCompleted { get; set; }
    }
}