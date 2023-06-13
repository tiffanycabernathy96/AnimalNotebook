using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AnimalNotebook.Models
{
    public enum RecurrenceType { Yearly, Monthly, Daily, Hourly }
    public class Medicine
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Brand is Required")]
        public string Brand { get; set; }

        [Display(Name = "Recurrence Amount")]
        public int RecurrenceAmount { get; set; }

        [Display(Name = "Recurrence Type")]
        public RecurrenceType RecurrenceType { get; set; }

        [Display(Name = "Last Date Given")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastDateGiven { get; set; }
        [Display(Name = "Animal Name")]
        public Guid animalId { get; set; }
    }
    public class MedicineDBContext : DbContext
    {
        //Should be a Table in the DB Named Medicines
        public DbSet<Medicine> Medicines { get; set; }
    }
}