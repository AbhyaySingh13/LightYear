using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.Models
{
    public class Meter : BaseEntity
    {
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Supplier { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}