using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.Models
{
    public class Customer : BaseEntity
    {
        public string UserId { get; set; }

        [StringLength(20)]
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(500)]
        [DisplayName("Residential Address")]
        public string ResidentialAddress { get; set; }

        [StringLength(10)]
        [DisplayName("Cell Number")]
        public string CellNumber { get; set; }
    }
}