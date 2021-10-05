using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.Models
{
    public class Technician : BaseEntity
    {
        [StringLength(20)]
        [DisplayName("Technician Name")]
        [Required]
        public string TechnicianName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [StringLength(10)]
        [DisplayName("Cell Number")]
        [Required]
        public string CellNumber { get; set; }
        public string Company { get; set; }


        [DisplayName("Callout Fee")]
        [Required]
        public decimal CalloutFee { get; set; }
    }
}