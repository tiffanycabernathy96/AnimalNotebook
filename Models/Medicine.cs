using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AnimalNotebook.Models
{
    public enum RecurrenceType { Yearly, Monthly, Daily, Hourly }
    public class Medicine
    {
        [Key]
        public Guid Id { get; set; }
        public string Brand { get; set; }
        [Display(Name = "Recurrence Amount")]
        public int RecurrenceAmount { get; set; }
        [Display(Name = "Recurrence Type")]
        public RecurrenceType RecurrenceType { get; set; }
        [Display(Name = "Last Date Given")]
        [DataType(DataType.Date)]
        public DateTime LastDateGiven { get; set; }
    }
}