using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AkuTakip.Business.Abstract;
using AkuTakip.Business.Constants;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.Business.Concrete
{
    public class GarantiDetayToAkuOzellikManager : IGarantiDetayToAkuOzellikService
    {
        private IGarantiDetayToAkuOzellikDal _garantiDetayToAkuOzellikDal;

        public GarantiDetayToAkuOzellikManager(IGarantiDetayToAkuOzellikDal garantiDetayToAkuOzellikDal)
        {
            _garantiDetayToAkuOzellikDal = garantiDetayToAkuOzellikDal;
        }

        public IDataResult<GarantiDetayToAkuOzellik> GetById(int garantiDetayToAkuOzellikId)
        {
            return new SuccessDataResult<GarantiDetayToAkuOzellik>(_garantiDetayToAkuOzellikDal.Get(p => p.GarantiDetayToAkuOzellikID == garantiDetayToAkuOzellikId));
        }

        public IDataResult<List<GarantiDetayToAkuOzellik>> GetList()
        {
            return new SuccessDataResult<List<GarantiDetayToAkuOzellik>>(_garantiDetayToAkuOzellikDal.GetList().ToList());
        }

        public IDataResult<List<GarantiDetayToAkuOzellik>> GetListByGarantiDetayId(int garantiDetayId)
        {
            return new SuccessDataResult<List<GarantiDetayToAkuOzellik>>(_garantiDetayToAkuOzellikDal.GetList(p=>p.GarantiDetayID == garantiDetayId).ToList());
        }

        public IResult Add(GarantiDetayToAkuOzellik garantiDetayToAkuOzellik)
        {
            _garantiDetayToAkuOzellikDal.Add(garantiDetayToAkuOzellik);
            return new SuccessResult();
        }

        public IResult Delete(GarantiDetayToAkuOzellik garantiDetayToAkuOzellik)
        {
            _garantiDetayToAkuOzellikDal.Delete(garantiDetayToAkuOzellik);
            return new SuccessResult();
        }

        public IResult Update(GarantiDetayToAkuOzellik garantiDetayToAkuOzellik)
        {
            _garantiDetayToAkuOzellikDal.Update(garantiDetayToAkuOzellik);
            return new SuccessResult();
        }
    }
}
