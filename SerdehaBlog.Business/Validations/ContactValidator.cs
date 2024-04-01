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
		}
    }
}
