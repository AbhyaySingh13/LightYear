using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightYear.WebUI.Controllers
{
    public class BaksetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Learn More About Us.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Feel Free To Contact Us Via.";

            return View();
        }
    }
}