using FluentValidation;
using SerdehaBlog.Entity.Concrete;

namespace SerdehaBlog.Business.Validations
{
    public class ArticleValidator:AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.AppUserId).NotEmpty().WithMessage("Oluşturan kullanıcı boş bırakılamaz.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Lütfen bir kategori seçiniz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlığı boş bırakılamaz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş bırakılamaz.");
            RuleFor(x => x.Content).MinimumLength(300).WithMessage("En az 300 kelimelik içerik girilmelidir.");
            RuleFor(x => x.SeoAuthor).NotEmpty().WithMessage("Yazar boş bırakılamaz.");
            RuleFor(x => x.SeoDescription).NotEmpty().WithMessage("Makale açıklaması boş bırakılamaz.");
            RuleFor(x => x.SeoTags).NotEmpty().WithMessage("Anahtar kelimeler boş bırakılamaz.");
        }
    }
}
