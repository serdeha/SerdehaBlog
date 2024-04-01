using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlığı boş bırakamazsın.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("İçeriği boş bırakamazsın.");
        }
    }
}
