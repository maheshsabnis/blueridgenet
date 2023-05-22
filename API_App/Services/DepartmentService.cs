using API_App.MOdels;
using Microsoft.EntityFrameworkCore;

namespace API_App.Services
{
    public class DepartmentService : IService<Department, int>
    {
        private readonly BlueCompanyContext ctx;
        ResponseObject<Department> response;

        public DepartmentService(BlueCompanyContext context)
        {
                ctx = context;
            response = new ResponseObject<Department>();
        }

        async Task<ResponseObject<Department>> IService<Department, int>.CreateAsync(Department entity)
        {
            var result =  await ctx.Departments.AddAsync(entity);
            await ctx.SaveChangesAsync();
            response.Record = result.Entity;
            response.Message = "Record Added Successfully";
            return response;
        }

        async Task<ResponseObject<Department>> IService<Department, int>.DeleteAsync(int id)
        {
            response.Record = await ctx.Departments.FindAsync(id);
            ctx.Departments.Remove(response.Record);
            await ctx.SaveChangesAsync();
            response.Message = "Record Deleted Successfully";
            return response;
        }

        async Task<ResponseObject<Department>> IService<Department, int>.GetAsync()
        {
            response.Records = await ctx.Departments.ToListAsync();
            return response;
        }

        async Task<ResponseObject<Department>> IService<Department, int>.GetAsync(int id)
        {
            response.Record = await ctx.Departments.FindAsync(id);
            response.Message = "Record Found Successfully";
            return response;
        }

        async Task<ResponseObject<Department>> IService<Department, int>.UpdateAsync(Department entity)
        {
            Department dept = await ctx.Departments.FindAsync(entity.DeptNo);
            dept.DeptName = entity.DeptName;
            dept.Location   = entity.Location;
            dept.Capacity = entity.Capacity;
            await ctx.SaveChangesAsync();
            response.Record = dept;
            response.Message = "Record updated Successfully";
            return response;
        }
    }
}
