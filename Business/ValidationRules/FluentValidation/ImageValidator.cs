using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.ImageId).NotEmpty();
            RuleFor(p => p.ImagePath).NotEmpty(); 
            RuleFor(p => p.Date).NotEmpty();
        }
    }
}
