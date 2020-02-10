using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
