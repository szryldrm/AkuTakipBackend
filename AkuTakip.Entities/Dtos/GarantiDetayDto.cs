using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Dtos
{
    public class GarantiDetayDto:IDto
    {
        public int GarantiDetayID { get; set; }
        public string SeriNo { get; set; }
        public Decimal Fiyat { get; set; }
        public int AkuTipiID { get; set; }
        public int AmperID { get; set; }
        public int MarkaID { get; set; }
        public string PlakaNo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
