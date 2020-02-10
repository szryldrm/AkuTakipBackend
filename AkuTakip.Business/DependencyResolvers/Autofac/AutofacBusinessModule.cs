using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Business.Abstract;
using AkuTakip.Business.Concrete;
using AkuTakip.Core.Utilities.Interceptors;
using AkuTakip.Core.Utilities.Security.Jwt;
using AkuTakip.DataAccess.Abstract;
using AkuTakip.DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AkuTakip.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlakaManager>().As<IPlakaService>();
            builder.RegisterType<EfPlakaDal>().As<IPlakaDal>();

            builder.RegisterType<MarkaManager>().As<IMarkaService>();
            builder.RegisterType<EfMarkaDal>().As<IMarkaDal>();

            builder.RegisterType<AmperManager>().As<IAmperService>();
            builder.RegisterType<EfAmperDal>().As<IAmperDal>();

            builder.RegisterType<AkuTipiManager>().As<IAkuTipiService>();
            builder.RegisterType<EfAkuTipiDal>().As<IAkuTipiDal>();

            builder.RegisterType<AkuOzellikManager>().As<IAkuOzellikService>();
            builder.RegisterType<EfAkuOzellikDal>().As<IAkuOzellikDal>();

            builder.RegisterType<GarantiDetayManager>().As<IGarantiDetayService>();
            builder.RegisterType<EfGarantiDetay>().As<IGarantiDetayDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
