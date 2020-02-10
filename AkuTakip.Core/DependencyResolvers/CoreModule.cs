using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace AkuTakip.Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
