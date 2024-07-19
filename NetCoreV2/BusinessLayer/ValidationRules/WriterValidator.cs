using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Kısmı Bos Geçilemez");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("E mail Boş Geçilemez").EmailAddress();
            RuleFor(x => x.WriterPassword)
                .NotEmpty().WithMessage("Şifre Boş Geçilemez")
                .MinimumLength(8).WithMessage("En az 8 karakter olmalı")
                .MaximumLength(50).WithMessage("En fazla 50 karakter olmalı")
                .Matches("[A-Z]").WithMessage("En az bir büyük harf içermelidir")
                .Matches("[0-9]").WithMessage("En az bir sayı içermelidir");
        }
    }
}
