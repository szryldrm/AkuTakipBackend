using AkuTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AkuTakip.Core.Utilities.Results;

namespace AkuTakip.Business.Abstract
{
    public interface IAmperService
    {
        IDataResult<Amper> GetById(int amperId);
        IDataResult<List<Amper>> GetList();
        IResult Add(Amper amper);
        IResult Delete(Amper amper);
        IResult Update(Amper amper);
    }
}
