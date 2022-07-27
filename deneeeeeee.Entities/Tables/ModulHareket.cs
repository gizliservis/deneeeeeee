using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Entities.Tables
{
    public class ModulHareket:EntityBase
    {
        public int MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }
        public int ModulId { get; set; }
        public virtual Modul Modul { get; set; }
        public DateTime ModulTarihi { get; set; }
        public decimal Miktar { get; set; }
        public decimal Fiyat { get; set; }
    }
}
