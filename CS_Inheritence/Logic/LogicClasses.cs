using CS_Inheritence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inheritence.Logic
{
    public abstract class EmployeeLogic
    {
        /// <summary>
        /// Abstract Method does not have any implementation
        /// THis MUST be overriden by the derived class
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public abstract List<Employee> AddEmployee(Employee employee);

        /// <summary>
        /// Virual Method has an implementation
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public virtual double GetNetSalary(Employee employee)
        {
            return employee.Salary;
        }
    }

    public class DirectorLogic : EmployeeLogic
    {
        List<Director> directors = new List<Director>();

        public override List<Employee> AddEmployee(Employee employee)
        {
            // List of EMployee
            var employees = new List<Employee>();   

            // Since the List takes Director object
            // Cast the EMployee to Director because
            // Each Director is-a EMployee
            directors.Add((Director)employee);


            // Add Each Director from Director List to Employee List
            foreach (var director in directors)
            {
                // Adding each Director from Directors lst to
                // Employee List because Each Director is Employee
                employees.Add(director);
            }
            return employees;
        }

        public override double GetNetSalary(Employee employee)
        {
            double sal =   base.GetNetSalary(employee); // BAse class Implementation as it is
            // Salary Calculations only for Director

            Director director = (Director)employee;

            double NetSalary = sal + director.VehicleAllowance + director.FlightAllowance + director.FoodAllowance;

            return NetSalary;
        }
    }


    public class ManagerLogic : EmployeeLogic
    {
        List<Manager> managers = new List<Manager> ();
        public override List<Employee> AddEmployee(Employee employee)
        {
            var employees = new List<Employee>();
            managers.Add((Manager)employee);

            foreach (var manager in managers)
            {
                employees.Add(manager);
            }
            return employees;
        }

        public override double GetNetSalary(Employee employee)
        {
             var sal = base.GetNetSalary (employee);

             Manager manager = (Manager)employee;

            var netsalary = sal + manager.TravelAllowance + manager.PetrolAllownce;
            return netsalary;
        }

    }
}
