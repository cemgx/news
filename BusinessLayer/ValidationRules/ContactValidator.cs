using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınızı boş bırakamazsınız.")
                .MinimumLength(3).WithMessage("Adınız en az 3 karakter olabilir.")
                .MaximumLength(50).WithMessage("Adınız en fazla 50 karakter olabilir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadınızı boş bırakamazsınız.")
                .MinimumLength(2).WithMessage("Soyadınız en az 2 karakter olabilir.")
                .MaximumLength(50).WithMessage("Soyadınız en fazla 50 karakter olabilir.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Adresinizi boş bırakamazsınız.")
                .EmailAddress().WithMessage("Mail Adresinizi kontrol ediniz.")
                .MaximumLength(50).WithMessage("Mail Adresiniz en fazla 50 karakter olabilir.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş bırakamazsınız.")
                .MaximumLength(50).WithMessage("Konu en fazla 50 karakter olabilir.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj kısmını boş bırakamazsınız.");
        }
    }
}
