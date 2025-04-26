using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez!")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır!");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Boş Geçilemez!");
            
            RuleFor(x => x.Raiting).NotEmpty().WithMessage("Puan Boş Geçilemez!")
                .InclusiveBetween(1, 5).WithMessage("Puan 1 ile 5 arasında olmalıdır!");

        }
    }
}
