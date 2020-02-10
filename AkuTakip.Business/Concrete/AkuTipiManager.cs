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
    public class AkuTipiManager : IAkuTipiService
    {
        private IAkuTipiDal _akuTipiDal;

        public AkuTipiManager(IAkuTipiDal akuTipiDal)
        {
            _akuTipiDal = akuTipiDal;
        }

        public IDataResult<AkuTipi> GetById(int akuTipiId)
        {
            return new SuccessDataResult<AkuTipi>(_akuTipiDal.Get(p => p.AkuTipiID == akuTipiId));
        }

        public IDataResult<List<AkuTipi>> GetList()
        {
            return new SuccessDataResult<List<AkuTipi>>(_akuTipiDal.GetList().ToList());
        }

        public IResult Add(AkuTipi akuTipi)
        {
            _akuTipiDal.Add(akuTipi);
            return new SuccessResult(Messages.AkuTipiAdded);
        }

        public IResult Delete(AkuTipi akuTipi)
        {
            _akuTipiDal.Delete(akuTipi);
            return new SuccessResult(Messages.AkuTipiDeleted);
        }

        public IResult Update(AkuTipi akuTipi)
        {
            _akuTipiDal.Update(akuTipi);
            return new SuccessResult(Messages.AkuTipiUpdated);
        }
    }
}
