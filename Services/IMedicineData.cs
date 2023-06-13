using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Services
{
    public interface IMedicineData
    {
        IEnumerable<Medicine> GetMedicines();

        IEnumerable<Medicine> GetMedicinesByAnimal(Guid animalId);

        Medicine GetMedicine(Guid id);

        void AddMedicine(Medicine medicine);

        void EditMedicine(Medicine medicine);

        void DeleteMedicine(Medicine medicine);
        void Dispose();
    }
}
