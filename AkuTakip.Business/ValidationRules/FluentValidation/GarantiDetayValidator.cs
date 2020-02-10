using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AkuTakip.Business.Constants;
using AkuTakip.Entities.Concrete;
using FluentValidation;

namespace AkuTakip.Business.ValidationRules.FluentValidation
{
    public class GarantiDetayValidator:AbstractValidator<GarantiDetay>
    {
        public GarantiDetayValidator()
        {
            RuleFor(g => g.SeriNo).NotEmpty();
            RuleFor(g => g.SeriNo).MinimumLength(3);
            RuleFor(g => g.SeriNo).Must(NonStartWithZero).WithMessage(Messages.NonStartWithZero);
        }

        private bool NonStartWithZero(string arg)
        {
            if (!arg.StartsWith("0"))
            {
                return true;
            }

            return false;
        }
    }
}
