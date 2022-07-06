using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Project
{
    public class HouseType
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Specifications { get; set; }
        public string FloorPlan { get; set; }
    }
}
