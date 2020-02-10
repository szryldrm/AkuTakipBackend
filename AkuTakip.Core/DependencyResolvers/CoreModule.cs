using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AkuTakip.Core.CrossCuttingConcerns.Caching;
using AkuTakip.Core.CrossCuttingConcerns.Caching.Microsoft;
using AkuTakip.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AkuTakip.Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
