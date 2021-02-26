using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class CarImageValidator: AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ImagePath).NotEmpty();
        }
    }
}
