using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Entities.Admin
{
    public class CompanyDetail
    {
        [Key]
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters allowed.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
    }
}
