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
    public class AmperManager : IAmperService
    {
        private IAmperDal _amperDal;

        public AmperManager(IAmperDal amperDal)
        {
            _amperDal = amperDal;
        }

        public IDataResult<Amper> GetById(int amperId)
        {
            return new SuccessDataResult<Amper>(_amperDal.Get(p => p.AmperID == amperId));
        }

        public IDataResult<List<Amper>> GetList()
        {
            return new SuccessDataResult<List<Amper>>(_amperDal.GetList().ToList());
        }

        public IResult Add(Amper amper)
        {
            _amperDal.Add(amper);
            return new SuccessResult(Messages.AmperAdded);
        }

        public IResult Delete(Amper amper)
        {
            _amperDal.Delete(amper);
            return new SuccessResult(Messages.AmperDeleted);
        }

        public IResult Update(Amper amper)
        {
            _amperDal.Update(amper);
            return new SuccessResult(Messages.AmperUpdated);
        }
    }
}
