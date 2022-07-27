using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Entities.Tables
{
    public class Modul:EntityBase
    {
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }
        public string Icerik { get; set; }
        public ICollection<ModulHareket> ModulHareketleri { get; set; }
    }
}
