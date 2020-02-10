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
    public class AkuOzellikManager : IAkuOzellikService
    {
        private IAkuOzellikDal _akuOzellikDal;

        public AkuOzellikManager(IAkuOzellikDal akuOzellikDal)
        {
            _akuOzellikDal = akuOzellikDal;
        }

        public IDataResult<AkuOzellik> GetById(int akuOzellikId)
        {
            return new SuccessDataResult<AkuOzellik>(_akuOzellikDal.Get(p => p.AkuOzellikID == akuOzellikId));
        }

        public IDataResult<List<AkuOzellik>> GetList()
        {
            return new SuccessDataResult<List<AkuOzellik>>(_akuOzellikDal.GetList().ToList());
        }

        public IResult Add(AkuOzellik akuOzellik)
        {
            _akuOzellikDal.Add(akuOzellik);
            return new SuccessResult(Messages.AkuOzellikAdded);
        }

        public IResult Delete(AkuOzellik akuOzellik)
        {
            _akuOzellikDal.Delete(akuOzellik);
            return new SuccessResult(Messages.AkuOzellikDeleted);
        }

        public IResult Update(AkuOzellik akuOzellik)
        {
            _akuOzellikDal.Update(akuOzellik);
            return new SuccessResult(Messages.AkuOzellikUpdated);
        }
    }
}
