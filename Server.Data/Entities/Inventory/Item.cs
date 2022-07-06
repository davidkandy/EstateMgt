using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities.Inventory
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ItemType Type { get; set; }
        public decimal Price { get; set; }
        public string UnitOfMeasurement { get; set; }
        public float? QuantityInStock { get; set; }
    }
}
