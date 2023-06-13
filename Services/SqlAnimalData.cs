using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Services
{
    public class SqlAnimalData : IAnimalData
    {
        private readonly AnimalDBContext db;
        public SqlAnimalData(AnimalDBContext db)
        {
            this.db = db;
        }
        public void AddAnimal(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
        }

        public void DeleteAnimal(Animal animal)
        {
            db.Animals.Remove(animal);
            db.SaveChanges();
        }

        public void EditAnimal(Animal animal)
        {
            var entry = db.Entry(animal);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Animal GetAnimal(Guid id)
        {
            return db.Animals.Find(id);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return db.Animals.OrderBy(a => a.Type);
        }

        public IEnumerable<Animal> GetAnimals(AnimalType Breed)
        {
            return db.Animals.Where(a => a.Type == Breed);
        }
        public void Dispose()
        {
            db.Dispose();    
        }
    }
}
