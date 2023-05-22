using System;
using System.Collections.Generic;

namespace API_App.MOdels
{
    public partial class Employee : EntityBase
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int Salary { get; set; }
        public int DeptNo { get; set; }

        public virtual Department DeptNoNavigation { get; set; } = null!;
    }
}
