using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AnimalNotebook.Models
{
    public enum AnimalType { Dog, Cat, Reptile, Rodent}
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        public AnimalType Type { get; set; }
        [Required(ErrorMessage = "Breed is Required")]
        public string Breed { get; set; }
        public List<Guid> Medicines { get; set; } = new List<Guid>();
        public List<Guid> Appointments { get; set; } = new List<Guid>();
    }
    public class AnimalDBContext : DbContext
    {
        //Should be a Table in the DB Named Animals
        public DbSet<Animal> Animals { get; set; }
    }
}