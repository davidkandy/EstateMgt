using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTOs.Admin
{
    public class HousingBlockForUpdate
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Description { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Status { get; set; }
        public int NumberOfUnits { get; set; }
        public string EstateId { get; set; }
    }
}
