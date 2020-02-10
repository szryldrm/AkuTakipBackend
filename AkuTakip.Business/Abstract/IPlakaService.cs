using AkuTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AkuTakip.Core.Utilities.Results;

namespace AkuTakip.Business.Abstract
{
    public interface IPlakaService
    {
        IDataResult<Plaka> GetById(int plakaId);
        IDataResult<List<Plaka>> GetList();
        IResult Add(Plaka plaka);
        IResult Delete(Plaka plaka);
        IResult Update(Plaka plaka);
    }
}
