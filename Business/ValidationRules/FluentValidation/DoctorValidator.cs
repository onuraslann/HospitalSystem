using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class DoctorValidator:AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.FirstName).MaximumLength(2);
            RuleFor(d => d.LastName).NotEmpty();
        }
    }
}
