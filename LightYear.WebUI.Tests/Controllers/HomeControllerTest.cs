using LightYear.Core.Contracts;
using LightYear.Core.Models;
using LightYear.Core.ViewModels;
using LightYear.WebUI;
using LightYear.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LightYear.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    { 
        
        public class UnitTest1
        {
            [TestMethod]
            public void IndexPageDoesReturnProducts()
            {
                IRepository<Meter> meterContext = new LightYear.Tests.Mocks.MockContext<Meter>();
                IRepository<Supplier> SupplierContext = new LightYear.Tests.Mocks.MockContext<Supplier>();

                meterContext.Insert(new Meter());

                MeterManagerController controller = new MeterManagerController(meterContext, SupplierContext);

                var result = controller.Index() as ViewResult;
                var viewModel = result.ViewData.Model as MeterListViewModel;

                Assert.AreEqual(1, viewModel.Meters.Count());

            }
        }

    }
}