using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class GalleryValidator : AbstractValidator<Gallery>
    {
        public GalleryValidator()
        {
            RuleFor(x => x.Photo).NotEmpty().WithMessage("Resim Boş Geçilemez!");
        }
    }
}
