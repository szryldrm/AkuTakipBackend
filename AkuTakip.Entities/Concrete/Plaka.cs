using AkuTakip.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkuTakip.Entities.Concrete
{
    public class Plaka:IEntity
    {
        public int PlakaID { get; set; }
        public string PlakaNo { get; set; }
    }
}
