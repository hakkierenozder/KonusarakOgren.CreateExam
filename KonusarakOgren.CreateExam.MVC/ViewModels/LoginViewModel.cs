using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.CreateExam.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email adresiniz")]
        public string Email { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "{0} alanı  en az {2} karakter uzunluğunda olmalıdır..", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }
    }
}
