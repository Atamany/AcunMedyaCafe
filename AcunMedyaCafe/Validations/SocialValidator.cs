using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class SocialValidator : AbstractValidator<Social>
    {
        public SocialValidator()
        {
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform Adı Boş Geçilemez!");

            RuleFor(x => x.AccountUrl).NotEmpty().WithMessage("Hesap Linki Boş Geçilemez!");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Boş Geçilemez!");
        }
    }
}
