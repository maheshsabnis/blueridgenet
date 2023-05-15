using CS_EFCoreAppStructure.Services;
using CS_EFCoreAppStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EFCoreAppStructureResponseObject.Business
{
    public class BusinessClass
    {
        IServices<Department,int> deptServ;

        public BusinessClass() 
        {
            deptServ = new DepartmentService();
        }

        public Department AddDept(Department dept)
        {
            // Vaidate Department
            if (!ValidateDepartment(dept)) return null;
            // check if deptno already exist, if exist return null
            if (!CheckIfDeptExist(dept.DeptNo)) return null;

            dept = deptServ.Create(dept);
            return dept;
        }

        public Department UpdateDept(Department dept)
        {
            if (!ValidateDepartment(dept)) return null;
            // check if deptno already exist, if exist return null
            if (!CheckIfDeptExist(dept.DeptNo)) return null;
            dept = deptServ.Update(dept.DeptNo, dept);
            return dept;
        }

        /// <summary>
        /// Helper method to validate the department 
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        private bool ValidateDepartment(Department dept)
        {
            if (dept.DeptNo < 0 || dept.DeptName == string.Empty || dept.Capacity < 0 || dept.Location == string.Empty)
            {
                return false;
            }
            return true;
        }

        public bool CheckIfDeptExist(int deptno)
        { 
            var dept = deptServ.Get(deptno);
            if (dept == null) return false;
            return true;
        }




    }
}
