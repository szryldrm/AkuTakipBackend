using AkuTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AkuTakip.Core.Utilities.Results;

namespace AkuTakip.Business.Abstract
{
    public interface IAkuTipiService
    {
        IDataResult<AkuTipi> GetById(int akuTipiId);
        IDataResult<List<AkuTipi>> GetList();
        IResult Add(AkuTipi akuTipi);
        IResult Delete(AkuTipi akuTipi);
        IResult Update(AkuTipi akuTipi);
    }
}
