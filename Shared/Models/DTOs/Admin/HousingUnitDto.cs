using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTOs.Admin
{
    public class HousingUnitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentOwnerId { get; set; }
        public string Status { get; set; }
        public DateOnly HandOverDate { get; set; }
        public string HousingBlockId { get; set; }
        public string HousingTypeId { get; set; }
    }
}
