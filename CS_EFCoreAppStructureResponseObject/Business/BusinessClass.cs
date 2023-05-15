using CS_EFCoreAppStructureResponseObject.Models;
using CS_EFCoreAppStructureResponseObject.Services;
using Microsoft.EntityFrameworkCore.Migrations;
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
        ResponseObject<Department> response = new ResponseObject<Department>();
        public BusinessClass() 
        {
            deptServ = new DepartmentService();
        }

        public ResponseObject<Department> AddDept(Department dept)
        {
            // Vaidate Department
            if (!ValidateDepartment(dept))
            {
                response.Message = "Department Values are not valid";
            }

            response =  deptServ.Create(dept);
            return response;
        }

        public ResponseObject<Department> UpdateDept(Department dept)
        {
            if (!ValidateDepartment(dept))
            {
                response.Message = "Department Values are not valid";
            }

            response = deptServ.Update(dept.DeptNo, dept);
            return response;
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

    }
}
