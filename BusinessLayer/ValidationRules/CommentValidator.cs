using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını boş bırakamazsınız.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanıcı Adı en fazla 50 karakter olabilir.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Kategori ismini boş bırakamazsınız.");
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Yorum kısmını boş bırakamazsınız.");
            RuleFor(x => x.CommentText).MinimumLength(10).WithMessage("Yorumunuz en az 10 karakter olabilir.");
            RuleFor(x => x.CommentText).MaximumLength(1000).WithMessage("Yorumunuz en fazla 1000 karakter olabilir.");
        }
    }
}
