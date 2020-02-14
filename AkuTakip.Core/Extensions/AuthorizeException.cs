using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AkuTakip.Core.Extensions
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(string message) : base(message)
        {

        }
    }
}
