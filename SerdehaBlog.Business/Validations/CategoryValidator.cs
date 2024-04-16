using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.AppUserId).NotEmpty().WithMessage("Oluşturan kullanıcı boş bırakılamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori ismi boş bırakılamaz.");
        }
    }
}
