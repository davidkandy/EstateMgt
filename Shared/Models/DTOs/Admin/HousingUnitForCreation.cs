using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTOs.Admin
{
    public class HousingUnitForCreation
    {
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Description { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Status { get; set; }
        public string CurrentOwnerId { get; set; }
        public DateOnly HandOverDate { get; set; }
        public string HousingBlockId { get; set; }
        public string HousingTypeId { get; set; }
    }
}
