using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidation : AbstractValidator<Author>
    {
        public AuthorValidation()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar ismini boş bırakamazsınız.");
            RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("Yazar ismi en az 2 karakter olabilir.");
            RuleFor(x => x.AuthorName).MaximumLength(50).WithMessage("Yazar ismi en fazla 50 karakter olabilir.");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar fotoğrafı boş bırakılamaz.");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazarın hakkında yazısı boş bırakılamaz.");
            RuleFor(x => x.AuthorAbout).MaximumLength(300).WithMessage("Yazarın hakkında yazısı en fazla 300 karakter olabilir.");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazarın mesleği boş bırakılamaz.");
            RuleFor(x => x.AuthorTitle).MaximumLength(50).WithMessage("Yazarın mesleği en fazla 50 karakter olabilir.");
            RuleFor(x => x.AuthorShortAbout).NotEmpty().WithMessage("Yazarın hakim olduğu başlıklar boş bırakılamaz.");
            RuleFor(x => x.AuthorShortAbout).MaximumLength(100).WithMessage("Yazarın hakim olduğu başlıklar en fazla 100 karakter olabilir.");
        }
    }
}
