using CS_Polymorphsim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Polymorphsim.Logic
{
    public sealed class Accounts
    {
        /// <summary>
        /// The GetTax() method will be having
        /// Polymorphic BEvaior based on Type of emp as well as type of logic
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="logic"></param>
        /// <returns></returns>
        public double GetTax(Employee emp, EmployeeLogic logic)
        {
            double sal = logic.GetNetSalary(emp);

            double tax = sal * 0.1;
            
            return tax;
        }
    }
}
