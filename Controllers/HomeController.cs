using AnimalNotebook.Models;
using AnimalNotebook.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalNotebook.Controllers
{
    public class HomeController : Controller
    {
        IAnimalData animalDb;
        IAppointmentData appointmentDb;
        IMedicineData medicineDb;


        public HomeController(IAnimalData animalDb, IAppointmentData appointmentDb, IMedicineData medicineDb)
        {
            this.animalDb = animalDb;
            this.appointmentDb = appointmentDb;
            this.medicineDb = medicineDb;
        }
        public ActionResult Index()
        {
            //HomeModel model = new HomeModel(animalDb, appointmentDb, medicineDb);
            
            HomeModel model = new HomeModel(animalDb, appointmentDb, medicineDb);
            model.Animal = new Animal();
            model.Appointment = new Appointment();
            model.Medicine = new Medicine();
            
            return View(model);
        }

        //public ActionResult Medicines()
        //{
        //    ViewBag.Message = "Where you can Add/Edit/Delete Medicine Reminders!";
        //    var model = medicineDb.GetMedicines();
        //    return View(model);
        //}

        public ActionResult Appointments()
        {
            ViewBag.Message = "Thank you for checking out my Demo Project. It has been a blast working through this project setup.";
            var model = appointmentDb.GetAppointments();
            return View(model);
        }
    }
}