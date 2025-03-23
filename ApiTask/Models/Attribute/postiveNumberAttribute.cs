using System.ComponentModel.DataAnnotations;

namespace ApiTask.Models.Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public class postiveNumberAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext? validationContext)
        {
            if (value != null)
            {
                double number = (double)value;
                if (number < 0)
                {
                    return new ValidationResult("The number must be positive.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
