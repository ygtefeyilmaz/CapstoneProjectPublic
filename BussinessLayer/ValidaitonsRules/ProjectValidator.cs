using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidaitonsRules
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Project_Name).NotEmpty().WithMessage("Project name cannot be empty!");
            RuleFor(x => x.Department_ID).NotEmpty().WithMessage("Department must be selected!");
        }
    }
}
