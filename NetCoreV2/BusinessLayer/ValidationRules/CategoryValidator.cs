using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(20).WithMessage("Daha kısa bir isim giriniz")
                .MinimumLength(3).WithMessage("3 karakterden uzun bir isim giriniz");
            RuleFor(x => x.CategoryDescription)
                .NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(150).WithMessage("Lütfen daha kısa bir açıklama giriniz");
           
        }
    }
}
