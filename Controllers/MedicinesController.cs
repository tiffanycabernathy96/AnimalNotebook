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
    public class MedicinesController : Controller
    {
        private IAnimalData animalDb;
        private IMedicineData db;
        public MedicinesController(IAnimalData animalDb, IMedicineData db)
        {
            this.animalDb = animalDb;
            this.db = db;  
        }

        // GET: Medicines
        public ActionResult Index()
        {
            return View(db.GetMedicines());
        }

        // GET: Medicines/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.GetMedicine(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            string name = animalDb.GetAnimal(medicine.animalId).Name;
            ViewBag.name = name;
            return View(medicine);
        }

        // GET: Medicines/Create
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

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Brand,RecurrenceAmount,RecurrenceType,LastDateGiven,animalId")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                medicine.Id = Guid.NewGuid();
                db.AddMedicine(medicine);
                return RedirectToAction("Index", "Home");
            }

            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.GetMedicine(id);
            if (medicine == null)
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
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,RecurrenceAmount,RecurrenceType,LastDateGiven,animalId")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.EditMedicine(medicine); 
                return RedirectToAction("Index", "Home");
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.GetMedicine(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            string name = animalDb.GetAnimal(medicine.animalId).Name;
            ViewBag.name = name;
            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.GetMedicine(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            db.DeleteMedicine(medicine);
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
