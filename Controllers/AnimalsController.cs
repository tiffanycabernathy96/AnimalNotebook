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

namespace AnimalNotebook.Controllers
{
    public class AnimalsController : Controller
    {
        //private AnimalDBContext db = new AnimalDBContext();
        private IAnimalData db;

        public AnimalsController(IAnimalData db)
        {
            this.db = db;
        }


        // GET: Animals
        public ActionResult Index()
        {
            var model = db.GetAnimals();
            return View(model);
        }

        // GET: Animals/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Age,Type,Breed")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                animal.Id = Guid.NewGuid();
                db.AddAnimal(animal);
                //db.Animals.Add(animal);
                //db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Type,Breed")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(animal).State = EntityState.Modified;
                //db.SaveChanges();
                db.EditAnimal(animal);
                return RedirectToAction("Index", "Home");
            }
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            db.deleteAnimal(animal);
            //db.Animals.Remove(animal);
            //db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
