using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.CrossCuttingConcerns.Caching;
using AkuTakip.Core.Utilities.Interceptors;
using AkuTakip.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace AkuTakip.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect:MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
