using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiTask.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterDTO 
    {
        [Required(ErrorMessage = "person name is reqired")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Email is reqired")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [Remote(action: "IsEmailInUse", controller: "Account",ErrorMessage = "email is already is use")]
        public string Email { get; set; }


        [Required(ErrorMessage = "PhoneNumber is reqired")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "phone should contain numbers only")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is reqired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is reqired")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword should match")]
        public string ConfirmPassword { get; set; }


    }
}
