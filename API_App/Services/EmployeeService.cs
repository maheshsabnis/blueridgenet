using API_App.MOdels;
using Microsoft.EntityFrameworkCore;

namespace API_App.Services
{
    public class EmployeeService : IService<Employee, int>
    {
        private readonly BlueCompanyContext ctx;
        ResponseObject<Employee> response;

        public EmployeeService(BlueCompanyContext context)
        {
                ctx = context;
            response = new ResponseObject<Employee>();
        }

        async Task<ResponseObject<Employee>> IService<Employee, int>.CreateAsync(Employee entity)
        {
            var result =  await ctx.Employees.AddAsync(entity);
            await ctx.SaveChangesAsync();
            response.Record = result.Entity;
            response.Message = "Record Added Successfully";
            return response;
        }

        async Task<ResponseObject<Employee>> IService<Employee, int>.DeleteAsync(int id)
        {
            response.Record = await ctx.Employees.FindAsync(id);
            ctx.Employees.Remove(response.Record);
            await ctx.SaveChangesAsync();
            response.Message = "Record Deleted Successfully";
            return response;
        }

        async Task<ResponseObject<Employee>> IService<Employee, int>.GetAsync()
        {
            response.Records = await ctx.Employees.ToListAsync();
            return response;
        }

        async Task<ResponseObject<Employee>> IService<Employee, int>.GetAsync(int id)
        {
            response.Record = await ctx.Employees.FindAsync(id);
            response.Message = "Record Found Successfully";
            return response;
        }

        async Task<ResponseObject<Employee>> IService<Employee, int>.UpdateAsync(Employee entity)
        {
            Employee emp = await ctx.Employees.FindAsync(entity.EmpNo);
            emp.EmpName = entity.EmpName;
            emp.Designation   = entity.Designation;
            emp.Salary = entity.Salary;
            emp.DeptNo  = entity.DeptNo;
            await ctx.SaveChangesAsync();
            response.Record = emp;
            response.Message = "Record updated Successfully";
            return response;
        }
    }
}
