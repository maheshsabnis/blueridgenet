using CS_EFCoreAppStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EFCoreAppStructure.Services
{
    public class EmployeeService : IServices<Employee, int>
    {
        Employee IServices<Employee, int>.Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        bool IServices<Employee, int>.Delete(int pk)
        {
            throw new NotImplementedException();
        }

        List<Employee> IServices<Employee, int>.Get()
        {
            throw new NotImplementedException();
        }

        Employee IServices<Employee, int>.Get(int pk)
        {
            throw new NotImplementedException();
        }

        Employee IServices<Employee, int>.Update(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
