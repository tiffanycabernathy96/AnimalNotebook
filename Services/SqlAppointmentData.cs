using AnimalNotebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalNotebook.Services
{
    public class SqlAppointmentData : IAppointmentData
    {
        private readonly AppointmentDBContext db;
        public SqlAppointmentData(AppointmentDBContext db)
        {
            this.db = db;
        }

        public void AddAppointment(Appointment appointment)
        {
            db.Appointments.Add(appointment);
            db.SaveChanges();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            db.Appointments.Remove(appointment);
            db.SaveChanges();
        }

        public void EditAppointment(Appointment appointment)
        {
            var entry = db.Entry(appointment);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Appointment GetAppointment(Guid id)
        {
            return db.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            var appoints = db.Appointments.OrderBy(a => a.animalId).ToList();
            return db.Appointments.OrderBy(a => a.animalId);
        }

        public IEnumerable<Appointment> GetAppointmentsByAnimal(Guid animalId)
        {
            return db.Appointments.Where(a => a.animalId == animalId);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
