using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
	public class ContactValidator : AbstractValidator<Contact>
	{
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen isminizi boş bırakmayınız.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen e-mail adresinizi giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen konu başlığını giriniz.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Lütfen mesajınızı giriniz.");
            RuleFor(x => x.Text).MaximumLength(1000).WithMessage("1000 karakterden uzun mesaj gönderemezsiniz.");
            RuleFor(x => x.Text).MinimumLength(35).WithMessage("35 karakterden az mesaj gönderemezsiniz.");
        }
    }
}
