using AkuTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AkuTakip.Core.Utilities.Results;

namespace AkuTakip.Business.Abstract
{
    public interface IAkuOzellikService
    {
        IDataResult<AkuOzellik> GetById(int akuOzellikId);
        IDataResult<List<AkuOzellik>> GetList();
        IResult Add(AkuOzellik akuOzellik);
        IResult Delete(AkuOzellik akuOzellik);
        IResult Update(AkuOzellik akuOzellik);
    }
}
