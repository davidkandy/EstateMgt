using Server.Data.Entities;
using Server.Data.Profiles.CustomMappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.CoreEntities
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

        //public Address Address { get; set; }
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
        public int FKCompanyId { get; set; }

        /*
         * I had to change this from Company, to string 
         * */
        [ForeignKey("FKCompanyId")]
        public string Company {get; set;}

        //public DateOnly StartDate { get; set; }
        //public DateOnly DateCompleted { get; set; }
    }
}