using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CreatedByName).NotEmpty().WithMessage("İsim kısmını boş bırakamazsınız");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Metin kısmını boş bırakamazsınız");
        }
    }
}
