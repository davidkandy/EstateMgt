using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Project
{
    public class BuildingStage
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; } 
        public string Description { get; set; }
    }
}
