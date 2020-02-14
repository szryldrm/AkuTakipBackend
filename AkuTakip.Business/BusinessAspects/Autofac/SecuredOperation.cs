using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Business.Constants;
using AkuTakip.Core.Extensions;
using AkuTakip.Core.Utilities.Interceptors;
using AkuTakip.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AkuTakip.Business.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }

            throw new AuthorizeException(Messages.AuthorizationDenied);
        }
    }
}
