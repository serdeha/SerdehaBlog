using System.ComponentModel.DataAnnotations;

namespace SerdehaBlog.WebUI.Areas.Admin.Models
{
    public class UserChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şu anki Şifre")]
        public string? CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string? NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Şifreyi Doğrula")]
        [Compare("NewPassword", ErrorMessage = "Lütfen şifrelerinizi doğru giriniz.")]
        public string? ConfirmPassword { get; set; }
    }
}
