using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Entities.Tables
{
    public class YedeklemeHareket:EntityBase
    {
        public string YedeklemeIslemi { get; set; }
        public int MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
