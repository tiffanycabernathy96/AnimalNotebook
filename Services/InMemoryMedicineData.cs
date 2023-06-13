using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalNotebook.Services
{
    public class InMemoryMedicineData : IMedicineData
    {
        List<Medicine> medicines;

        public InMemoryMedicineData()
        {
            medicines = new List<Medicine>();
        }

        public void AddMedicine(Medicine medicine)
        {
            medicines.Add(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            medicines.Remove(medicine);
        }

        public void EditMedicine(Medicine medicine)
        {
            var index = medicines.FindIndex(a => a.Id == medicine.Id);
            if(index != -1)
            {
                medicines[index] = medicine;
            }
        }

        public Medicine GetMedicine(Guid id)
        {
            return medicines.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return medicines.OrderBy(a => a.animalId);
        }

        public IEnumerable<Medicine> GetMedicinesByAnimal(Guid animalId)
        {
            return medicines.Where(a => a.animalId == animalId);
        }
        public void Dispose()
        {

        }
    }
}
