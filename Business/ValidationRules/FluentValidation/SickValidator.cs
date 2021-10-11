using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class SickValidator:AbstractValidator<Sick>
    {
        public SickValidator()
        {
            RuleFor(s => s.Tc).MaximumLength(11);
            RuleFor(s => s.FatherName).NotEmpty();
        }
    }
}
