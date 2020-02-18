using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;
using AkuTakip.Entities.Concrete;

namespace AkuTakip.Entities.Dtos
{
    public class GarantiDetayDto:IDto
    {
        public int GarantiDetayID { get; set; }
        public string SeriNo { get; set; }
        public Decimal Fiyat { get; set; }
        public string AkuTipi { get; set; }
        public string Amper { get; set; }
        public string Marka { get; set; }
        public string PlakaNo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<AkuOzellik> AkuOzellik { get; set; }
    }
}
