using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Descriptions).NotEmpty();
            RuleFor(c => c.Descriptions).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Descriptions).Must(NotStartsWithSpace).WithMessage("Car model MUST NOT start with space");
        }

        private bool NotStartsWithSpace(string arg)
        {
            return !arg.StartsWith(" ");
        }
    }
}
