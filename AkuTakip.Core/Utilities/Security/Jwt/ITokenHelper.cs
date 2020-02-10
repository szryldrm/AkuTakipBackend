using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.Concrete;

namespace AkuTakip.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
