using AcunMedyaCafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Ürün Adı en az 3 karakter olmalıdır!");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı Boş Geçilemez!")
                .GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan büyük olmalıdır!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün Açıklaması Boş Geçilemez!")
                .MinimumLength(10).WithMessage("Ürün Açıklaması en az 10 karakter olmalıdır!");

            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Ürün Resmi Boş Geçilemez!");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Seçimi Boş Geçilemez!")
                .GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçin!");
        }
    }
}
