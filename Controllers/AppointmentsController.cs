using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalNotebook.Models;
using AnimalNotebook.Services;

namespace AnimalNotebook
{
    public class AppointmentsController : Controller
    {
        private IAnimalData animalDb;
        private IAppointmentData db;

        public AppointmentsController(IAnimalData animalDb, IAppointmentData db)
        {
            this.animalDb = animalDb;
            this.db = db;
        }

        // GET: Appointments
        public ActionResult Index()
        {    
            return View(db.GetAppointments());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.GetAppointment(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            string name = animalDb.GetAnimal(appointment.animalId).Name;
            ViewBag.name = name;
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            IEnumerable<Animal> animals = animalDb.GetAnimals().ToList();
            List<SelectListItem> selectList = animals.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            ViewBag.Animals = selectList;
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VetOffice,VetOfficeAddress,Date,animalId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Id = Guid.NewGuid();
                db.AddAppointment(appointment);
                return RedirectToAction("Index", "Home");
            }

            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.GetAppointment(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Animal> animals = animalDb.GetAnimals().ToList();
            List<SelectListItem> selectList = animals.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            ViewBag.Animals = selectList;
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VetOffice,VetOfficeAddress,Date,animalId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.EditAppointment(appointment);
                return RedirectToAction("Index", "Home");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.GetAppointment(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            string name = animalDb.GetAnimal(appointment.animalId).Name;
            ViewBag.name = name;
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.GetAppointment(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            db.DeleteAppointment(appointment);
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
