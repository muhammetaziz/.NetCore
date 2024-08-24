using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Hakkımızda kısmı boş geçilemez")
                .MinimumLength(150).WithMessage("Minimum 150 karakter uzunlugunda olmalı"); 
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Hakkımızda kısmı boş geçilemez")
                .MinimumLength(150).WithMessage("Minimum 150 karakter uzunlugunda olmalı");
            RuleFor(x => x.AboutImage1).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.AboutImage2).NotEmpty().WithMessage("Boş Geçemezsiniz");
            


        }

    }
}
