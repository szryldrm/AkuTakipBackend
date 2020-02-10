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
            RuleFor(gd => gd.SeriNo).NotEmpty();
            RuleFor(gd => gd.SeriNo).MinimumLength(3);
            RuleFor(gd => gd.SeriNo).Must(NonStartWithZero).WithMessage(Messages.NonStartWithZero);
            RuleFor(gd => gd.AkuTipiID).NotEmpty().WithMessage(Messages.NotEmptyAkuTipi);
            RuleFor(gd => gd.AmperID).NotEmpty().WithMessage(Messages.NotEmptyAmper);
            RuleFor(gd => gd.MarkaID).NotEmpty().WithMessage(Messages.NotEmptyMarka);

        }

        private bool NonStartWithZero(string arg)
        {
            return !arg.StartsWith("0");
        }
    }
}
