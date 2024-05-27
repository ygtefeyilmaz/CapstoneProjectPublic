using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidaitonsRules
{
    public class ResultValidator : AbstractValidator<Result>
    {
        public ResultValidator()
        {
            RuleFor(x => x.Project_ID).NotEmpty().WithMessage("Project cannot be null!");
            RuleFor(x => x.Team_ID).NotEmpty().WithMessage("Team cannot be null!");

        }
    }
}
