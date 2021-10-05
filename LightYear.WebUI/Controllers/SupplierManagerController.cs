using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightYear.Core.Models;
using LightYear.Core.Contracts;

namespace LightYear.WebUI.Controllers
{
    public class SupplierManagerController : Controller
    {
        IRepository<Supplier> context;
        public SupplierManagerController(IRepository<Supplier> context)
        {
            this.context = context;
        }
        // GET: SupplierManager
        public ActionResult Index()
        {
            List<Supplier> suppliers = context.Collection().ToList();
            return View(suppliers);
        }

        public ActionResult Create()
        {
            Supplier supplier = new Supplier();
            return View(supplier);
        }
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }
            else
            {
                context.Insert(supplier);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Supplier supplier = context.Find(Id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(supplier);
            }
        }
        [HttpPost]
        public ActionResult Edit(Supplier supplier, string Id)
        {
            Supplier supplierToEdit = context.Find(Id);
            if (supplierToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(supplier);
                }

                supplierToEdit.SupplierName = supplier.SupplierName;


                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Supplier supplierToDelete = context.Find(Id);

            if (supplierToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(supplierToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Supplier supplierToDelete = context.Find(Id);

            if (supplierToDelete == null)
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