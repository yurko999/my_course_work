using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Ім'я")]
        [StringLength(20)]
        [Required(ErrorMessage = "Ім'я не введено")]
        public string Name { get; set; }

        [Display(Name = "Прізвище")]
        [StringLength(20)]
        [Required(ErrorMessage = "Прізвище не введено")]
        public string SurName { get; set; }

        [Display(Name = "Адреса")]
        [StringLength(40)]
        [Required(ErrorMessage = "Адресу не введено")]
        public string Address{ get; set; }

        [Display(Name = "Номер телефону")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Телефон не введено")]
        public string Phone { get; set; }

        [Display(Name = "Пошта")]
        [EmailAddress(ErrorMessage = "Пошту введено неправильно")]
        [StringLength(40)]
        [Required(ErrorMessage = "Пошту не введено")]
        public string Email { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
