using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalNotebook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Medicines()
        {
            ViewBag.Message = "Where you can Add/Edit/Delete Medicine Reminders!";

            return View();
        }

        public ActionResult Appointments()
        {
            ViewBag.Message = "Where you can Add/Edit/Delete Appointment Reminders!";

            return View();
        }
    }
}