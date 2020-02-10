using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.Concrete;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
