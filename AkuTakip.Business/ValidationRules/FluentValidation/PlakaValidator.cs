using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Entities.Concrete;
using FluentValidation;

namespace AkuTakip.Business.ValidationRules.FluentValidation
{
    public class PlakaValidator:AbstractValidator<Plaka>
    {
        public PlakaValidator()
        {
            RuleFor(p => p.PlakaNo).NotEmpty();
            RuleFor(p => p.PlakaNo).Length(2, 30);
        }
    }
}
