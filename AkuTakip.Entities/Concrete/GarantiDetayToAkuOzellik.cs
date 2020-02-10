using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Concrete
{
    public class GarantiDetayToAkuOzellik:IEntity
    {
        public int GarantiDetayToAkuOzellikID { get; set; }
        public int GarantiDetayID { get; set; }
        public int AkuOzellikID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
