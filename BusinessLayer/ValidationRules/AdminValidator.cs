using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adınızı boş bırakamazsınız.");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Kullanıcı adınız en fazla 30 karakter olabilir.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi boş bırakamazsınız.");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifreniz en fazla 20 karakter olabilir.");
        }
    }
}
