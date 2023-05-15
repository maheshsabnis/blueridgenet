using CS_EFCoreAppStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EFCoreAppStructure.Services
{
    public class DepartmentService : IServices<Department, int>
    {
        CompanyContext ctx;

        public DepartmentService()
        {
            ctx = new CompanyContext();
        }

        Department IServices<Department, int>.Create(Department entity)
        {
            var result = ctx.Departments.Add(entity);
            ctx.SaveChanges();
            return result.Entity;
        }

        bool IServices<Department, int>.Delete(int pk)
        {
            var dept = ctx.Departments.Find(pk);
            if(dept == null) return false;
            ctx.Departments.Remove(dept);
            ctx.SaveChanges();
            return true;
        }

        List<Department> IServices<Department, int>.Get()
        {
            return ctx.Departments.ToList();
        }

        Department IServices<Department, int>.Get(int pk)
        {
            return ctx.Departments.Find(pk);
        }

        Department IServices<Department, int>.Update(int id, Department entity)
        {
            var dept = ctx.Departments.Find(id);
            if (dept == null) return null;

            dept.DeptName = entity.DeptName;
            dept.Capacity = entity.Capacity;
            dept.Location = entity.Location;
            ctx.SaveChanges();
            return dept;
        }
    }
}
