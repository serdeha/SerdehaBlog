using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
    public class UserValidator:AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Ad kısmı boş bırakılamaz");
            RuleFor(x=>x.LastName).NotEmpty().WithMessage("Soyad kısmı boş bırakılamaz");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı adı kısmı boş bırakılamaz");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("E-mail kısmı boş bırakılamaz");
        }
    }
}
