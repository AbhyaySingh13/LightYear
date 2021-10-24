using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.Models
{
   public class Order: BaseEntity
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }
      
      
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string ResidentialAddress { get; set; }
      
        public string CellNumber{ get; set; }
        public string OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
