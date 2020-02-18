using AkuTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AkuTakip.Core.Utilities.Results;

namespace AkuTakip.Business.Abstract
{
    public interface IMarkaService
    {
        IDataResult<Marka> GetById(int markaId);
        IDataResult<Marka> GetByName(string marka);
        IDataResult<List<Marka>> GetList();
        IResult Add(Marka marka);
        IResult Delete(Marka marka);
        IResult Update(Marka marka);
    }
}
