using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationTool.Models
{   

    public enum Status
    {
        Approved, Pending, Rejected
    }

    public enum VacationType
    {
        Paid, Unpaid, SickLeave
    }

    public class Vacation
    {
        public int ID { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        
        public Status Status { get; set; }
        public string ManagerEmail { get; set; }
        public VacationType VacationType { get; set; }
       
        public int AmountOfDays { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }



    }
}