using System;

namespace VacationTool.Models
{   

    public enum Status
    {
        Approved, Pending, Rejected
    }

    public class Vacation
    {
        public int ID { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        
        public Status Status { get; set; }
       
        public int AmountOfDays { get; set; }

        public virtual Employee Employee{ get; set; }

    }
}