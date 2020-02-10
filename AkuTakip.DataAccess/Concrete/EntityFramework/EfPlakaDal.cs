using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.DataAccess.EntityFramework;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.DataAccess.Concrete.EntityFramework.Contexts;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.DataAccess.Concrete.EntityFramework
{
    public class EfPlakaDal:EfEntityRepositoryBase<Plaka, AkuTakipContext>, IPlakaDal
    {
    }
}
