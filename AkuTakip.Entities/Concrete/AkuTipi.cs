using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Concrete
{
    public class AkuTipi:IEntity
    {
        public int AkuTipiID { get; set; }
        public string AkuTipiName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
