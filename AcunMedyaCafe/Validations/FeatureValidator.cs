using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Subtitle).NotEmpty().WithMessage("Kısa Başlık Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Kısa Başlık en az 3 karakter olmalıdır!");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır!");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Boş Geçilemez!");
        }
    }
}
