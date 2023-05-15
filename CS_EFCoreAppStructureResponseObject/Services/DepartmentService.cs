using CS_EFCoreAppStructureResponseObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EFCoreAppStructureResponseObject.Services
{
    public class DepartmentService : IServices<Department, int>
    {
        CompanyContext ctx;
        ResponseObject<Department> response;
        public DepartmentService()
        {
            ctx = new CompanyContext();
            response = new ResponseObject<Department>();
        }

        ResponseObject<Department> IServices<Department, int>.Create(Department entity)
        {
            var result = ctx.Departments.Add(entity);
            ctx.SaveChanges();
            response.Record = result.Entity;
            response.Message = "Record added sueesccfuly";
            return response;
        }

        ResponseObject<Department> IServices<Department, int>.Delete(int pk)
        {
            var dept = ctx.Departments.Find(pk);
            if (dept == null)
            {
                response.Record = null;
                response.Message = "Record not found";
                return response;
            }

            ctx.Departments.Remove(dept);
            ctx.SaveChanges();
            response.Message = "Record deleted sueesccfuly";
            return response;
        }

        ResponseObject<Department> IServices<Department, int>.Get()
        {
             response.Records = ctx.Departments.ToList();
            return response;
        }

        ResponseObject<Department> IServices<Department, int>.Get(int pk)
        {
            var dept = ctx.Departments.Find(pk);
            if (dept == null)
            {
                response.Record = null;
                response.Message = "Record not found";
                return response;
            }
            response.Record = dept;
            response.Message = "Record  found";
            return response;

        }

        ResponseObject<Department> IServices<Department, int>.Update(int id, Department entity)
        {
            var dept = ctx.Departments.Find(id);
            if (dept == null)
            {
                response.Record = null;
                response.Message = "Record not found";
                return response;
            }

            dept.DeptName = entity.DeptName;
            dept.Capacity = entity.Capacity;
            dept.Location = entity.Location;
            ctx.SaveChanges();
            return response;
        }
    }
}
