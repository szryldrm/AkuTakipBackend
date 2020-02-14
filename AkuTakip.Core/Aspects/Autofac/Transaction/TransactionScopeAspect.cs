﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using AkuTakip.Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace AkuTakip.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
