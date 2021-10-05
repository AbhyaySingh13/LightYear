using LightYear.Core.Contracts;
using LightYear.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class TechnicianManagerController : Controller
    {
        IRepository<Technician> context;
        public TechnicianManagerController(IRepository<Technician> context)
        {
            this.context = context;
        }

        // GET: DriverManager
        public ActionResult Index()
        {
            List<Technician> technician = context.Collection().ToList();
            return View(technician);
        }

        public ActionResult Create()
        {
            Technician technician = new Technician();
            return View(technician);
        }
        [HttpPost]
        public ActionResult Create(Technician technician)
        {
            if (!ModelState.IsValid)
            {
                return View(technician);
            }
            else
            {
                context.Insert(technician);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Technician technician  = context.Find(Id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(technician);
            }
        }
        [HttpPost]
        public ActionResult Edit(Technician technician, string Id)
        {
            Technician technicianToEdit = context.Find(Id);
            if (technicianToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(technician);
                }

                technicianToEdit.TechnicianName = technician.TechnicianName;
                technicianToEdit.Email = technician.Email;
                technicianToEdit.CellNumber = technician.CellNumber;
                technicianToEdit.Company = technician.Company;
                technicianToEdit.CalloutFee = technician.CalloutFee;


                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Technician technicianToDelete = context.Find(Id);

            if (technicianToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(technicianToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Technician technicianToDelete = context.Find(Id);

            if (technicianToDelete == null)
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