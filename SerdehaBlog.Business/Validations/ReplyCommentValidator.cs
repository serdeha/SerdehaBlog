using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
	public class ReplyCommentValidator : AbstractValidator<ReplyComment>
	{
        public ReplyCommentValidator()
        {
			RuleFor(x => x.CreatedByName).NotEmpty().WithMessage("İsim kısmını boş bırakamazsınız");
			RuleFor(x => x.Text).NotEmpty().WithMessage("Metin kısmını boş bırakamazsınız");
		}
    }
}
