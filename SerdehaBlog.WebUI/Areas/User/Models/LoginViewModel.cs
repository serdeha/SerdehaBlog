using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SerdehaBlog.WebUI.Areas.User.Models
{
	public class LoginViewModel
	{
		[DisplayName("Kullanıcı Adı")]
		[Required(ErrorMessage = "{0} boş bırakılamaz.")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden fazla girilemez.")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden az girilemez.")]
		[DataType(DataType.Text)]
		public string? Username { get; set; }
		[DisplayName("Şifre")]
		[Required(ErrorMessage = "{0} boş bırakılamaz.")]
		[MaxLength(30, ErrorMessage = "{0} {1} karakterden fazla girilemez.")]
		[MinLength(5, ErrorMessage = "{0} {1} karakterden az girilemez.")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[DisplayName("Beni Hatırla")]
		public bool RememberMe { get; set; }
	}
}
