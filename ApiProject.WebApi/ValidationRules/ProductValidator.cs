using ApiProject.WebApi.Entities;
using FluentValidation;

namespace ApiProject.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product> 
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adını Boş Geçmeyin!");
            RuleFor(x=>x.ProductName).MinimumLength(2).WithMessage("Ürün Adı En Az 2 Karakter Olmalıdır!");
            RuleFor(x=>x.ProductName).MaximumLength(50).WithMessage("Ürün Adı En Fazla 50 Karakter Olmalıdır!");

            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat Boş Geçilemez!").GreaterThan(0).WithMessage("Fiyat Negatif Küçük Olamaz!").LessThan(10000).WithMessage("Fiyat 10000'den Büyük Olamaz!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez!");
        }
    }
}
