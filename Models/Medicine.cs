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
        public int RecurrenceAmount { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public DateTime LastDateGiven { get; set; }
    }
}