using AkuTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.Entities.Dtos;

namespace AkuTakip.Business.Abstract
{
    public interface IGarantiDetayService
    {
        IDataResult<GarantiDetay> GetById(int garantiDetayId);
        IDataResult<List<GarantiDetay>> GetList();
        IDataResult<List<GarantiDetay>> GetByPlaka(string plaka);
        IDataResult<List<GarantiDetay>> GetByPlakaWithDate(string plaka, string date1, string date2);
        IResult Add(GarantiDetayDto garantiDetayDto);
        IResult Delete(GarantiDetay garantiDetay);
        IResult Update(GarantiDetay garantiDetay);
    }
}
