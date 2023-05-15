using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SImpleClass.Models
{
    public class Employee
    {
        // Private Data Members
        int _EmpNo;
        string _EmpName;
        string _DeptName;
        string _Designation;
        decimal _Salary;
        decimal _Hra;
        decimal _Ta;
        decimal _Da;
        decimal _NetSalary;

        // Lets Write Constructor to initialize all Private members
        public Employee(int eno, string ename, string dname, string desig, decimal sal)
        {
            _EmpNo = eno;
            _EmpName = ename;
            _DeptName = dname;
            _Designation = desig;
            _Salary = sal;
        }

        // Lets write a method to calculate salary

        public decimal CalculateNetSalary()
        {
            Console.WriteLine("Employee Details");
            Console.WriteLine($"{_EmpNo} {_EmpName} {_DeptName} {_Designation} {_Salary}");
            
            // FIrst Calculate HRA, TA, DA
            _Hra = _Salary * Convert.ToDecimal(0.2);
            _Ta = _Salary * Convert.ToDecimal(0.15);
            _Da = _Salary * Convert.ToDecimal(0.25);

            _NetSalary = _Salary + _Hra + _Ta + _Da;
            return _NetSalary;

        }

    }
}
