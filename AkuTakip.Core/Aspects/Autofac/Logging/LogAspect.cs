using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AkuTakip.Core.CrossCuttingConcerns.Logging;
using AkuTakip.Core.CrossCuttingConcerns.Logging.Log4Net;
using AkuTakip.Core.Utilities.Interceptors;
using AkuTakip.Core.Utilities.Messages;
using Castle.DynamicProxy;

namespace AkuTakip.Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type LoggerService)
        {
            if (LoggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(LoggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });

            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                DateTime = DateTime.Now
            };

            return logDetail;
        }
    }
}
