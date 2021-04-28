﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).InclusiveBetween(0, 12);
        }
        
    }
}
