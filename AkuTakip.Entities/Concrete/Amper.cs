using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Entities;

namespace AkuTakip.Entities.Concrete
{
    public class Amper:IEntity
    {
        public int AmperID { get; set; }
        public string AmperNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
