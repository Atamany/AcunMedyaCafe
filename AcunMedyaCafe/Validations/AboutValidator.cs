using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Subitle).NotEmpty().WithMessage("Kısa Başlık Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Kısa Başlık en az 3 karakter olmalıdır!");
            
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır!");

            RuleFor(x => x.BoldText).NotEmpty().WithMessage("Alt Başlık Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Alt Başlık en az 3 karakter olmalıdır!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez!")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır!");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Boş Geçilemez!");

            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video Boş Geçilemez!");

        }
    }
}
