using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace homework_64.ViewModels
{
    public class ProfileEditViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckAccountName", "AccountValidation", ErrorMessage = "Логин занят")]
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Данные введены неверно")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckAccountEmail", "AccountValidation", ErrorMessage = "Email занят")]
        public string Email { get; set; }

        public int UserId { get; set; }
    }
}