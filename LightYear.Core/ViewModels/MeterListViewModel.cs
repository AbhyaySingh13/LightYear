using LightYear.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.ViewModels
{
    public class MeterListViewModel
    {
        public IEnumerable<Meter> Meters { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}