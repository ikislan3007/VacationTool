using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationTool.Models
{   

    public enum PositionInCompany
    {
        Junior,
        Mid,
        Senior
    }

    public enum Role
    {
        Manager,
        Developer,
        Recruiter

    }

    public class Position
    {
        public int ID { get; set; }

        public PositionInCompany PositionInCompany { get; set; }

        public Role Role { get; set; }

        public int Salary { get; set; }

        // public int YearsOfExperience { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
