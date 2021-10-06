using LightYear.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string MeterId { get; set; }
        public int Quantity { get; set; }
    }
}
