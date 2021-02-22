using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.FırstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Email).MinimumLength(5);
            RuleFor(p => p.Password).MinimumLength(1);
            RuleFor(p => p.Password).MaximumLength(15);
            
        }
    }
}
