using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AkuTakip.Business.Abstract;
using AkuTakip.Business.Constants;
using AkuTakip.Business.ValidationRules.FluentValidation;
using AkuTakip.Core.CrossCuttingConcerns.Validation;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.Entities.Concrete;


namespace AkuTakip.Business.Concrete
{
    public class PlakaManager : IPlakaService
    {
        private IPlakaDal _plakaDal;

        public PlakaManager(IPlakaDal plakaDal)
        {
            _plakaDal = plakaDal;
        }
        public IDataResult<Plaka> GetById(int plakaId)
        {
            return new SuccessDataResult<Plaka>(_plakaDal.Get(p => p.PlakaID == plakaId));
        }

        public IDataResult<List<Plaka>> GetList()
        {
            return new SuccessDataResult<List<Plaka>>(_plakaDal.GetList().ToList());
        }

        public IResult Add(Plaka plaka)
        {
            ValidationTool.Validate(new PlakaValidator(), plaka);
            _plakaDal.Add(plaka);
            return new SuccessResult(Messages.PlakaAdded);
        }

        public IResult Delete(Plaka plaka)
        {
            _plakaDal.Delete(plaka);
            return new SuccessResult(Messages.PlakaDeleted);
        }

        public IResult Update(Plaka plaka)
        {
            _plakaDal.Update(plaka);
            return new SuccessResult(Messages.PlakaUpdated);
        }
    }
}
