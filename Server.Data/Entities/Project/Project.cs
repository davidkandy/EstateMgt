using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Project
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public string SiteLocation { get; set; }    
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<HousingUnit> HousingUnits { get; set; }
    }
}
