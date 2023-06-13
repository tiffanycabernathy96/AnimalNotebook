using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Services
{
    public class SqlMedicineData : IMedicineData
    {
        private readonly MedicineDBContext db;
        public SqlMedicineData(MedicineDBContext db)
        {
            this.db = db;
        }

        public void AddMedicine(Medicine medicine)
        {
            db.Medicines.Add(medicine);
            db.SaveChanges();
        }

        public void DeleteMedicine(Medicine medicine)
        {
            db.Medicines.Remove(medicine);
            db.SaveChanges();
        }

        public void EditMedicine(Medicine medicine)
        {
            var entry = db.Entry(medicine);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Medicine GetMedicine(Guid id)
        {
            return db.Medicines.Find(id);
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return db.Medicines.OrderBy(a => a.animalId);
        }

        public IEnumerable<Medicine> GetMedicinesByAnimal(Guid animalId)
        {
            return db.Medicines.Where(a => a.animalId == animalId);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
