using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AkuTakip.Business.Abstract;
using AkuTakip.Business.Constants;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.Entities.Concrete;


namespace AkuTakip.Business.Concrete
{
    public class GarantiDetayManager : IGarantiDetayService
    {
        private IGarantiDetayDal _garantiDetayDal;
        private IPlakaDal _plakaDal;

        public GarantiDetayManager(IGarantiDetayDal garantiDetayDal, IPlakaDal plakaDal)
        {
            _garantiDetayDal = garantiDetayDal;
            _plakaDal = plakaDal;
        }

        public IDataResult<GarantiDetay> GetById(int garantiDetayId)
        {
            return new SuccessDataResult<GarantiDetay>(_garantiDetayDal.Get(p => p.GarantiDetayID == garantiDetayId));
        }

        public IDataResult<List<GarantiDetay>> GetByPlaka(string plaka)
        {
            var tempPlaka = _plakaDal.Get(p=>p.PlakaNo == plaka);

            if (tempPlaka != null)
            {
                return new SuccessDataResult<List<GarantiDetay>>(_garantiDetayDal.GetList(d => d.PlakaID == tempPlaka.PlakaID).ToList());
            }

            return new ErrorDataResult<List<GarantiDetay>>("Sonuç Bulunamadı.!");
        }

        public IDataResult<List<GarantiDetay>> GetByPlakaWithDate(string plaka, string date1, string date2)
        {
            var tempPlaka = _plakaDal.Get(p => p.PlakaNo == plaka);

            DateTime start = Convert.ToDateTime(date1);
            DateTime end = Convert.ToDateTime(date2);

            if (tempPlaka != null)
            {
                return new SuccessDataResult<List<GarantiDetay>>(_garantiDetayDal.GetList(d => d.PlakaID == tempPlaka.PlakaID && d.CreatedDate >= start && d.CreatedDate <= end).ToList());
            }

            return new ErrorDataResult<List<GarantiDetay>>("Sonuç Bulunamadı.!");
        }

        public IDataResult<List<GarantiDetay>> GetList()
        {
            return new SuccessDataResult<List<GarantiDetay>>(_garantiDetayDal.GetList().ToList());
        }

        public IResult Add(GarantiDetay garantiDetay)
        {
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
