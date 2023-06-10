using System.ComponentModel.DataAnnotations;
using System;

namespace AnimalNotebook.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Vet Office Name")]
        public string VetOffice { get; set; }
        [Display(Name = "Vet Office Address")]
        public string VetOfficeAddress { get; set; }
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

    }
}