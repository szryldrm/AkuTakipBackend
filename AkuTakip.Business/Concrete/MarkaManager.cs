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
    public class MarkaManager : IMarkaService
    {
        private IMarkaDal _markaDal;

        public MarkaManager(IMarkaDal markaDal)
        {
            _markaDal = markaDal;
        }

        public IDataResult<Marka> GetById(int markaId)
        {
            return new SuccessDataResult<Marka>(_markaDal.Get(p => p.MarkaID == markaId));
        }

        public IDataResult<Marka> GetByName(string marka)
        {
            return new SuccessDataResult<Marka>(_markaDal.Get(p => p.MarkaName == marka));

        }

        public IDataResult<List<Marka>> GetList()
        {
            return new SuccessDataResult<List<Marka>>(_markaDal.GetList().ToList());
        }

        public IResult Add(Marka marka)
        {
            _markaDal.Add(marka);
            return new SuccessResult(Messages.MarkaAdded);
        }

        public IResult Delete(Marka marka)
        {
            _markaDal.Delete(marka);
            return new SuccessResult(Messages.MarkaDeleted);
        }

        public IResult Update(Marka marka)
        {
            _markaDal.Update(marka);
            return new SuccessResult(Messages.MarkaUpdated);
        }
    }
}
