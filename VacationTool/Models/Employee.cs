using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VacationTool.Models
{
    public class Employee
    {

        public int ID { get; set; }

        public DateTime DateOfHire { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }
        public string  SecondName { get; set; }
        public string  Email { get; set; }
        
        public Gender Gender { get; set; }

        [ForeignKey("Position")]
        public int? PositionId { get; set; }

        public Position Position { get; set; }

        public virtual ICollection<Vacation>? Vacations { get; set; }
    }

    public enum Gender
    {
        MALE, FEMALE
    }
}
