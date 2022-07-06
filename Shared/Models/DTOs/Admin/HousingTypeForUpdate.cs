using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.DTOs.Admin
{
    public class HousingTypeForUpdate
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 50 characters allowed")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters allowed")]
        public string Description { get; set; }
        public int Size { get; set; }
        public string DesignFilesPath { get; set; }
        public string EstateId { get; set; }
    }
}
