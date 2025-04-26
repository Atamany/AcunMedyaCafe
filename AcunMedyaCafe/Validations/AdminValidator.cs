using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class AdminValidator : AbstractValidator<Entities.Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Kullanıcı Adı en az 3 karakter olmalıdır!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!")
                .MinimumLength(5).WithMessage("Şifre en az 5 karakter olmalıdır!")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$").WithMessage("Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.");

            RuleFor(x => x.ProfilePhoto).NotEmpty().WithMessage("Profil Resmi Boş Geçilemez!");
        }
    }
}
