using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces.Logic
{
    /// <summary>
    /// All Methods declared in interface must be implemented by class
    /// 1. Implicit IMplementation: Mehods are own by class and iterface
    /// 
    /// </summary>
    public class Mathematics : IMath, IMathNew
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y) 
        {
            return x - y; 
        }

     
    }

    /// <summary>
    /// Expliit Implementation of interface
    /// 2. Explicit Implemetation: Methods are implemented by class but always accessed and owned by interface
    /// </summary>
    public class MathematicsExplicit : IMath, IMathNew
    { 
        // THis will set the access specifier of the interface on methods
        int IMath.Add(int x, int y) {  return x + y; }

        int IMathNew.Add(int x, int y)
        {
             return (x * x) + 2 * x* y + (y * y);
        }

        int IMath.Subtract(int x, int y) { return x - y; }

        int IMathNew.Subtract(int x, int y)
        {
            return (x * x) - 2 * x * y + (y * y);
        }
    }


}
