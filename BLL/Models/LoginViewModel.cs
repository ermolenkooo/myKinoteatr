using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class LoginViewModel //модель дто для авторизации
    {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
    [Display(Name = "Запомнить?")]
    public bool RememberMe { get; set; }
    public string ReturnUrl { get; set; }
    }
}
