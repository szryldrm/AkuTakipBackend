using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using AkuTakip.Business.Abstract;
using AkuTakip.Business.BusinessAspects.Autofac;
using AkuTakip.Business.Constants;
using AkuTakip.Business.ValidationRules.FluentValidation;
using AkuTakip.Core.Aspects.Autofac.Caching;
using AkuTakip.Core.Aspects.Autofac.Logging;
using AkuTakip.Core.Aspects.Autofac.Performance;
using AkuTakip.Core.Aspects.Autofac.Validation;
using AkuTakip.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using AkuTakip.Core.CrossCuttingConcerns.Validation;
using AkuTakip.Core.Utilities.Business;
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

        public IDataResult<Plaka> GetByPlakaNo(string plakaNo)
        {
            return new SuccessDataResult<Plaka>(_plakaDal.Get(p => p.PlakaNo == plakaNo));
        }

        //[SecuredOperation("GarantiDetay.List, Admin", Priority = 1)]
        [CacheAspect(duration: 1, Priority = 2)]
        [PerformanceAspect(5)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Plaka>> GetList()
        {
            return new SuccessDataResult<List<Plaka>>(_plakaDal.GetList().ToList());
        }

        [ValidationAspect(typeof(PlakaValidator))]
        [CacheRemoveAspect("IPlakaService.Get")]
        [CacheRemoveAspect("IGarantiDetay.Get")]
        public IResult Add(Plaka plaka)
        {
            IResult result = BusinessRules.Run(CheckIfPlakaNoExists(plaka.PlakaNo));
            if (result != null)
            {
                return result;
            }
            _plakaDal.Add(plaka);
            return new SuccessResult(Messages.PlakaAdded);
        }

        private IResult CheckIfPlakaNoExists(string plakaNo)
        {
            if (_plakaDal.Get(p => p.PlakaNo == plakaNo) != null)
            {
                return new ErrorResult(Messages.PlakaAlreadyExists);
            }

            return new SuccessResult();
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
