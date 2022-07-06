using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Inventory
{
    public class StoreRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTimeOffset RequestDate { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public float Quantity { get; set; }
        public string Purpose { get; set; }
        public string RequestedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }

    }
}
