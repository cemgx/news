using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.NewsTitle).NotEmpty().WithMessage("Haber başlığını boş bırakamazsınız.");
            RuleFor(x => x.NewsTitle).MinimumLength(3).WithMessage("Haber başlığı en az 3 karakter olabilir.");
            RuleFor(x => x.NewsTitle).MaximumLength(100).WithMessage("Haber başlığı en fazla 100 karakter olabilir.");
            RuleFor(x => x.NewsContent).NotEmpty().WithMessage("Haber içeriğini boş bırakamazsınız.");
        }
    }
}
