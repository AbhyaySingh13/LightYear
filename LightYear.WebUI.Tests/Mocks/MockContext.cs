using LightYear.Core.Contracts;
using LightYear.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightYear.WebUI.Tests.Mocks
{
    public class MockContext<T> : IRepository<T> where T: BaseEntity
    {
    }
}
