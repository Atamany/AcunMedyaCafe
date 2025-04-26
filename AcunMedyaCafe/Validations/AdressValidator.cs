using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.WeekdayHours).NotEmpty().WithMessage("Haftaiçi Çalışma Saatleri Boş Geçilemez!");

            RuleFor(x => x.WeekendHours).NotEmpty().WithMessage("Haftasonu Çalışma Saatleri Boş Geçilemez!");

            RuleFor(x => x.Call).NotEmpty().WithMessage("Telefon Boş Geçilemez!")
                .MinimumLength(16).WithMessage("Telefon Numarası en az 16 karakter olmalıdır!")
                .MaximumLength(18).WithMessage("Telefon Numarası en fazla 18 karakter olmalıdır!");
        }
    }
}
