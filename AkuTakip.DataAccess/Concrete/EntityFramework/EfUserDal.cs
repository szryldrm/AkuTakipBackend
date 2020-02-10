using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AkuTakip.Core.DataAccess.EntityFramework;
using AkuTakip.Core.Utilities.Concrete;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.DataAccess.Concrete.EntityFramework.Contexts;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, AkuTakipContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new AkuTakipContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
