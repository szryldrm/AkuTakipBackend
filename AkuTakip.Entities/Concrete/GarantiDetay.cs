using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Concrete
{
    public class GarantiDetay:IEntity
    {
        public int GarantiDetayID { get; set; }
        public string SeriNo { get; set; }
        public Decimal Fiyat { get; set; }
        public int AkuTipiID { get; set; }
        public int AmperID { get; set; }
        public int MarkaID { get; set; }
        public int PlakaID { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Description { get; set; }
    }
}
