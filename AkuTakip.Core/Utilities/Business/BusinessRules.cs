using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.Results;

namespace AkuTakip.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
