using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Inventory
{
    public class StoreCheckIn
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public DateTimeOffset CheckInDate { get; set; }
        [Required]
        public virtual Store Store { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public string ReceivedBy { get; set; }
        public string DeliveredBy { get; set; }
        public string Notes { get; set; }
        public string Remarks { get; set; }
    }
}
