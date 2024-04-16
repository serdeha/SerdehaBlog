using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SerdehaBlog.WebUI.Areas.Admin.Models
{
    public class UserUpdateViewModel
    {
        [DisplayName("İsim")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? FirstName { get; set; }
        [DisplayName("Soyisim")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        public string? LastName { get; set; }
        [DisplayName("E-posta")]
        [Required(ErrorMessage = "Lütfen {0} alanını boş bırakmayınız.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }
        [DisplayName("Resim Dosyası")]
        public string? ImageUrl { get; set; }
    }
}
