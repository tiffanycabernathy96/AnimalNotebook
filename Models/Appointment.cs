using System.ComponentModel.DataAnnotations;
using System;
using System.Data.Entity;

namespace AnimalNotebook.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }
        public string VetOffice { get; set; }
        public string VetOfficeAddress { get; set; }
        public string Date { get; set; }

    }
}