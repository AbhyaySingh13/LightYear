using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightYear.Core.Models;
using LightYear.Core.ViewModels;
using LightYear.Core.Contracts;
using System.IO;

namespace LightYear.WebUI.Controllers
{
    public class MeterManagerController : Controller
    {
        IRepository<Meter> context;
        IRepository<Supplier> meterSupplier;

        public MeterManagerController(IRepository<Meter> meterContext, IRepository<Supplier> meterSupplierContext) //Needs to inject Repositories from DI Container
        {
            context = meterContext;
            meterSupplier = meterSupplierContext;
        }
        // GET: MeterManager
        public ActionResult Index()
        {
            List<Meter> meters = context.Collection().ToList();
            return View(meters);
        }
        public ActionResult DisplayMeters(string MeterSupplier = null)
        {
            List<Meter> meters;
            List<Supplier> suppliers = meterSupplier.Collection().ToList();

            if (MeterSupplier == null)
            {
                meters = context.Collection().ToList();
            }
            else
            {
                meters = context.Collection().Where(p => p.Supplier == MeterSupplier).ToList();
            }

            MeterListViewModel model = new MeterListViewModel();
            model.Meters = meters;
            model.Suppliers = suppliers;

            return View(model);
        }
        public ActionResult Create()
        {
            MeterManagerViewModel viewModel = new MeterManagerViewModel();

            viewModel.Meter = new Meter();
            viewModel.Supplier = meterSupplier.Collection();

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Meter meter, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(meter);
            }
            else
            {
                if (file != null)
                {
                    meter.Image = meter.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//MeterImages//") + meter.Image);
                }
                context.Insert(meter);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Meter meter = context.Find(Id);
            if (meter == null)
            {
                return HttpNotFound();
            }
            else
            {
                MeterManagerViewModel viewModel = new MeterManagerViewModel();
                viewModel.Meter = meter;
                viewModel.Supplier = meterSupplier.Collection();

                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Meter meter, string Id, HttpPostedFileBase file)
        {
            Meter meterToEdit = context.Find(Id);
            if (meterToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(meter);
                }

                if (file != null)
                {
                    meterToEdit.Image = meter.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//MeterImages//") + meterToEdit.Image);
                }

                meterToEdit.Name = meter.Name;
                meterToEdit.Supplier = meter.Supplier;
                meterToEdit.Description = meter.Description;
                meterToEdit.Stock = meter.Stock;
                meterToEdit.Price = meter.Price;

                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Meter meterToDelete = context.Find(Id);

            if (meterToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(meterToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Meter meterToDelete = context.Find(Id);

            if (meterToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}