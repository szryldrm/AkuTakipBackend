using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Concrete
{
    public class AkuOzellik:IEntity
    {
        public int AkuOzellikID { get; set; }
        public string AkuOzellikName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
