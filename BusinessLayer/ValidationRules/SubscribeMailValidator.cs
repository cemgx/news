using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeValidator : AbstractValidator<SubscribeMail>
    {
        public SubscribeValidator()
        {
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Mail Adresinizi kontrol ediniz.")
                .MaximumLength(50).WithMessage("Mail Adresiniz en fazla 50 karakter olabilir.");
        }
    }
}
