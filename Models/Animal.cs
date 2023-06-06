using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AnimalNotebook.Models
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
    public class AnimalDBContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
    }
}