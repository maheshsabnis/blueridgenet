using CS_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LINQ.Database
{
    public class EmployeesDb : List<Employee>
    {
        public EmployeesDb()
        {
            Add(new Employee() { EmpNo = 1, EmpName = "Ajay", DeptName = "D1", Salary = 10000 });
            Add(new Employee() { EmpNo = 2, EmpName = "Bjay", DeptName = "D2", Salary = 20000 });
            Add(new Employee() { EmpNo = 3, EmpName = "Cjay", DeptName = "D3", Salary = 30000 });
            Add(new Employee() { EmpNo = 4, EmpName = "Djay", DeptName = "D4", Salary = 40000 });
            Add(new Employee() { EmpNo = 5, EmpName = "Ejay", DeptName = "D1", Salary = 10000 });
            Add(new Employee() { EmpNo = 6, EmpName = "Fjay", DeptName = "D2", Salary = 30000 });
            Add(new Employee() { EmpNo = 7, EmpName = "Gjay", DeptName = "D3", Salary = 40000 });
            Add(new Employee() { EmpNo = 8, EmpName = "Hjay", DeptName = "D4", Salary = 50000 });
            Add(new Employee() { EmpNo = 9, EmpName = "Ijay", DeptName = "D1", Salary = 20000 });
            Add(new Employee() { EmpNo = 10, EmpName = "Jjay", DeptName = "D2", Salary = 60000 });
            Add(new Employee() { EmpNo = 11, EmpName = "Kjay", DeptName = "D3", Salary = 70000 });
            Add(new Employee() { EmpNo = 12, EmpName = "Ljay", DeptName = "D4", Salary = 30000 });
            Add(new Employee() { EmpNo = 13, EmpName = "Mjay", DeptName = "D1", Salary = 80000 });
            Add(new Employee() { EmpNo = 14, EmpName = "Njay", DeptName = "D2", Salary = 90000 });
            Add(new Employee() { EmpNo = 15, EmpName = "Ojay", DeptName = "D3", Salary = 30000 });
            Add(new Employee() { EmpNo = 16, EmpName = "Pjay", DeptName = "D4", Salary = 60000 });
            Add(new Employee() { EmpNo = 17, EmpName = "Qjay", DeptName = "D1", Salary = 40000 });
            Add(new Employee() { EmpNo = 18, EmpName = "Rjay", DeptName = "D2", Salary = 30000 });
            Add(new Employee() { EmpNo = 19, EmpName = "Sjay", DeptName = "D3", Salary = 50000 });
            Add(new Employee() { EmpNo = 20, EmpName = "Tjay", DeptName = "D4", Salary = 90000 });
        }
    }
}
