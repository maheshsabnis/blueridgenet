using Core_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_MVC.Services
{
    public class EmployeeService : IServices<Employee, int>
    {
        BlueCompanyContext ctx;
        ResponseObject<Employee> response;
        public EmployeeService()
        {
             
            response = new ResponseObject<Employee>();
        }

        ResponseObject<Employee> IServices<Employee, int>.Create(Employee entity)
        {
            var result = ctx.Employees.Add(entity);
            ctx.SaveChanges();
            response.Record = result.Entity;
            response.Message = "Record added sueesccfuly";
            return response;
        }

        ResponseObject<Employee> IServices<Employee, int>.Delete(int pk)
        {
            var emp = ctx.Employees.Find(pk);
            if (emp == null)
            {
                response.Record = null;
                response.Message = "Record not found";
                return response;
            }

            ctx.Employees.Remove(emp);
            ctx.SaveChanges();
            response.Message = "Record deleted sueesccfuly";
            return response;
        }

        ResponseObject<Employee> IServices<Employee, int>.Get()
        {
             response.Records = ctx.Employees.ToList();
            return response;
        }

        ResponseObject<Employee> IServices<Employee, int>.Get(int pk)
        {
            var emp = ctx.Employees.Find(pk);
            if (emp == null)
            {
                response.Record = null;
                response.Message = "Record not found";
                return response;
            }
            response.Record = emp;
            response.Message = "Record  found";
            return response;

        }

        ResponseObject<Employee> IServices<Employee, int>.Update(int id, Employee entity)
        {
            var emp = ctx.Employees.Find(id);
            if (emp == null)
            {
                response.Record = null;
                response.Message = "Record not found";
                return response;
            }

            emp.EmpName = entity.EmpName;
            emp.Designation = entity.Designation;
            emp.Salary = entity.Salary;
            emp.DeptNo = entity.DeptNo;

            ctx.SaveChanges();
            return response;
        }
    }
}
