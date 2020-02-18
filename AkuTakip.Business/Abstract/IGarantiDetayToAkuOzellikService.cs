using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.Business.Abstract
{
    public interface IGarantiDetayToAkuOzellikService
    {
        IDataResult<GarantiDetayToAkuOzellik> GetById(int garantiDetayToAkuOzellikId);
        IDataResult<List<GarantiDetayToAkuOzellik>> GetList();
        IDataResult<List<GarantiDetayToAkuOzellik>> GetListByGarantiDetayId(int garantiDetayId);
        IResult Add(GarantiDetayToAkuOzellik garantiDetayToAkuOzellik);
        IResult Delete(GarantiDetayToAkuOzellik garantiDetayToAkuOzellik);
        IResult Update(GarantiDetayToAkuOzellik garantiDetayToAkuOzellik);
    }
}
