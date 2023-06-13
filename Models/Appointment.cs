using System.ComponentModel.DataAnnotations;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalNotebook.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Vet Office Name")]
        public string VetOffice { get; set; }
        [Display(Name = "Vet Office Address")]
        public string VetOfficeAddress { get; set; }
        [Required(ErrorMessage = "Appointment Date is Required")]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Display(Name = "Animal Name")]
        public Guid animalId { get; set; }

    }
    public class AppointmentDBContext : DbContext
    {
        //Should be a Table in the DB Named Appointments
        public DbSet<Appointment> Appointments { get; set; }
    }
}