using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidaitonsRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
          RuleFor(x => x.projectChoice1).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice2).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice3).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice4).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice5).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice6).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice7).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice8).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice9).NotEmpty().WithMessage("Proje alanı boş geçilemez!");
          RuleFor(x => x.projectChoice10).NotEmpty().WithMessage("Proje alanı boş geçilemez!");

        }
    }
}
