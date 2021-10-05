using LightYear.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.Core.ViewModels
{
    public class MeterManagerViewModel
    {
        public Meter Meter { get; set; }
        public IEnumerable<Supplier> Supplier { get; set; }
    }
}