using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Required(ErrorMessage = "DeptNo is required")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = "DeptName is required")]
        public string DeptName { get; set; } = null!;
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = null!;
        [Required(ErrorMessage = "Capacity is required")]
        ///The Custom Validation ANnotation
        [NonNetgative(ErrorMessage = "Capacity canot be -Ve")]
        public int Capacity { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
