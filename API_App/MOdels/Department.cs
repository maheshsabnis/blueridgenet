using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_App.MOdels
{
    public partial class Department : EntityBase
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Required(ErrorMessage ="DeptNO is required")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = "DeptName is required")]
        public string DeptName { get; set; } = null!;
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = null!;
        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
