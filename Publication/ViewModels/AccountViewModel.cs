using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.ViewModels
{
    public class AccountViewModel
    {
        [Display(Name = "Логін")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Мінімум 5 символів")]
        [Required(ErrorMessage = "Логін не введено")]
        public string Login { get; set; }

        [Display(Name = "Пошта")]
        [StringLength(40)]
        [EmailAddress(ErrorMessage = "Пошта введена неправильно")]
        [Required(ErrorMessage = "Пошту не введено")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль не введено")]
        public string Password { get; set; }

        [Display(Name = "Підтвердження паролю")]
        [Required(ErrorMessage = "Повторно пароль не введено")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }
    }
}
