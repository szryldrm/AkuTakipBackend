using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.DataAccess;
using AkuTakip.Core.Utilities.Concrete;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
