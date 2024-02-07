using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator() 
        {
            RuleFor(x => x.AboutContent1).NotEmpty().WithMessage("Hakkında 1 kısmını boş bırakamazsınız.");
            RuleFor(x => x.AboutContent1).MaximumLength(500).WithMessage("Hakkında 1 kısmı en fazla 500 karakter olabilir.");
            RuleFor(x => x.AboutContent2).NotEmpty().WithMessage("Hakkında 2 kısmını boş bırakamazsınız.");
            RuleFor(x => x.AboutContent2).MaximumLength(500).WithMessage("Hakkında 2 kısmı en fazla 500 karakter olabilir.");
        }
    }
}
