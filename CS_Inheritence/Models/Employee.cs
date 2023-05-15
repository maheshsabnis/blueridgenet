using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CS_Inheritence.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string? EmpName { get; set; }
        public string? DeptName { get; set; }
        public double Salary { get; set; }
    }

    /// <summary>
    /// Director is derived from Employee
    /// Director is-a Employee
    /// </summary>
    public class Director : Employee 
    {
        public double FlightAllowance { get; set; }
        public double VehicleAllowance { get; set; }
        public double FoodAllowance { get; set; }
    }

    /// <summary>
    /// Manager is-a Employee
    /// </summary>
    public class Manager : Employee
    {
        public double TravelAllowance { get; set; }
        public double PetrolAllownce { get; set; }
    }

}
