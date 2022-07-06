using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Project
{
    public class HousingUnit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Project Project { get; set; }
        [Required]
        public virtual HouseType HouseType { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentOwner { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DateCompleted { get; set; }
        public DateTimeOffset HandoverDate { get; set; }
        public virtual ProjectMember Supervisor { get; set; }
        public string Status { get; set; }
        public virtual BuildingStage CurrentStage { get; set; }
        public decimal AmountSold { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
    }
}
