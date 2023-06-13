using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalNotebook.Services
{
    public class InMemoryAppointmentData : IAppointmentData
    {
        List<Appointment> appointments;

        public InMemoryAppointmentData()
        {
            appointments = new List<Appointment>();
        }

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
        }

        public void EditAppointment(Appointment appointment)
        {
            var index = appointments.FindIndex(a => a.Id == appointment.Id);
            if (index != -1)
            {
                appointments[index] = appointment;
            }
        }

        public IEnumerable<Appointment> GetAppointmentsByAnimal(Guid animalId)
        {
            return appointments.Where(a => a.animalId == animalId);
        }

        public Appointment GetAppointment(Guid id)
        {
            return appointments.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return appointments.OrderBy(a => a.Date);
        }
        public void Dispose()
        {

        }
    }
}
