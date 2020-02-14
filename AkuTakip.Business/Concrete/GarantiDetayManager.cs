using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AkuTakip.Business.Abstract;
using AkuTakip.Business.Constants;
using AkuTakip.Business.ValidationRules.FluentValidation;
using AkuTakip.Core.Aspects.Autofac.Caching;
using AkuTakip.Core.Aspects.Autofac.Logging;
using AkuTakip.Core.Aspects.Autofac.Transaction;
using AkuTakip.Core.Aspects.Autofac.Validation;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.Entities.Concrete;
using AkuTakip.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using AkuTakip.Core.Utilities.Business;
using AkuTakip.Entities.Dtos;


namespace AkuTakip.Business.Concrete
{
    public class GarantiDetayManager : IGarantiDetayService
    {
        private IGarantiDetayDal _garantiDetayDal;
        private IPlakaService _plakaService;


        public GarantiDetayManager(IGarantiDetayDal garantiDetayDal, IPlakaService plakaService)
        {
            _garantiDetayDal = garantiDetayDal;
            _plakaService = plakaService;
        }

        public IDataResult<GarantiDetay> GetById(int garantiDetayId)
        {
            return new SuccessDataResult<GarantiDetay>(_garantiDetayDal.Get(p => p.GarantiDetayID == garantiDetayId));
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<GarantiDetay>> GetByPlaka(string plaka)
        {
            var tempPlaka = _plakaService.GetByPlakaNo(plaka);

            if (tempPlaka.Data != null)
            {
                return new SuccessDataResult<List<GarantiDetay>>(_garantiDetayDal.GetList(d => d.PlakaID == tempPlaka.Data.PlakaID).ToList());
            }

            return new ErrorDataResult<List<GarantiDetay>>(Messages.NoResultsFound);
        }

        public IDataResult<List<GarantiDetay>> GetByPlakaWithDate(string plaka, string date1, string date2)
        {
            var tempPlaka = _plakaService.GetByPlakaNo(plaka);

            DateTime start = Convert.ToDateTime(date1);
            DateTime end = Convert.ToDateTime(date2);

            if (tempPlaka != null)
            {
                return new SuccessDataResult<List<GarantiDetay>>(_garantiDetayDal.GetList(d => d.PlakaID == tempPlaka.Data.PlakaID && d.CreatedDate >= start && d.CreatedDate <= end).ToList());
            }

            return new ErrorDataResult<List<GarantiDetay>>(Messages.NoResultsFound);
        }

        public IDataResult<List<GarantiDetay>> GetList()
        {
            return new SuccessDataResult<List<GarantiDetay>>(_garantiDetayDal.GetList().ToList());
        }

        [ValidationAspect(typeof(GarantiDetayValidator), Priority = 1)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IGarantiDetay.Get")]
        public IResult Add(GarantiDetayDto garantiDetayDto)
        {
            Plaka tempPlaka = new Plaka
            {
                PlakaNo = garantiDetayDto.PlakaNo.ToUpper()
            };

            var resultPlaka = _plakaService.Add(tempPlaka);

            if (!resultPlaka.Success)
            {
                tempPlaka = _plakaService.GetByPlakaNo(tempPlaka.PlakaNo).Data;
            }

            GarantiDetay garantiDetay = new GarantiDetay
            {
                SeriNo = garantiDetayDto.SeriNo,
                Fiyat = garantiDetayDto.Fiyat,
                AkuTipiID = garantiDetayDto.AkuTipiID,
                AmperID = garantiDetayDto.AmperID,
                MarkaID = garantiDetayDto.MarkaID,
                PlakaID = tempPlaka.PlakaID,
                Description = garantiDetayDto.Description,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            _garantiDetayDal.Add(garantiDetay);
            return new SuccessResult(Messages.GarantiDetayAdded);
        }

        public IResult Delete(GarantiDetay garantiDetay)
        {
            _garantiDetayDal.Delete(garantiDetay);
            return new SuccessResult(Messages.GarantiDetayDeleted);
        }

        public IResult Update(GarantiDetay garantiDetay)
        {
            _garantiDetayDal.Update(garantiDetay);
            return new SuccessResult(Messages.GarantiDetayUpdated);
        }

    }
}
