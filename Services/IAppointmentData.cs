using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Services
{
    public interface IAppointmentData
    {
        IEnumerable<Appointment> GetAppointments();

        IEnumerable<Appointment> GetAppointmentsByAnimal(Guid animalId);

        Appointment GetAppointment(Guid id);

        void AddAppointment(Appointment appointment);

        void EditAppointment(Appointment appointment);

        void DeleteAppointment(Appointment appointment);
        void Dispose();
    }
}
