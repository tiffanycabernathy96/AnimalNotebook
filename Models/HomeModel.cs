using AnimalNotebook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Models
{
    
    public class HomeModel
    {
        public Animal Animal { get; set; }
        public Appointment Appointment { get; set; }
        public Medicine Medicine { get; set; }

        IAnimalData animalDb;
        IAppointmentData appointmentDb;
        IMedicineData medicineDb;
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Medicine> Medicines { get; set; }


        public HomeModel(IAnimalData animalDb, IAppointmentData appointmentDb, IMedicineData medicineDb)
        {
            this.animalDb = animalDb;
            this.appointmentDb = appointmentDb;
            this.medicineDb = medicineDb;
            Animals = this.animalDb.GetAnimals();
            Appointments = this.appointmentDb.GetAppointments();
            Medicines = this.medicineDb.GetMedicines();
        }
    }
}
