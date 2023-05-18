using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models
{
    public class NonNetgativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int val = Convert.ToInt32(value);
            if(val < 0) return false;
            return true;
        }
    }
}
