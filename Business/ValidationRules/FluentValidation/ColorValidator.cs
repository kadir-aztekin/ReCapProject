using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {

        public ColorValidator()
        {
            RuleFor(p => p.ColorName).Must(StartWihA).WithMessage("Renkler A bile başlamalı");
            R
            

        }

        private bool StartWihA(string arg)
        {
            throw new NotImplementedException();
        }
    }
}
