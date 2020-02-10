using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.Concrete;
using AkuTakip.Core.Utilities.Results;
using AkuTakip.Core.Utilities.Security.Jwt;
using AkuTakip.Entities.Dtos;

namespace AkuTakip.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
