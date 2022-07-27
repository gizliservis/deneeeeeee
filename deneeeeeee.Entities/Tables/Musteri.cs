using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Entities.Tables
{
   public class Musteri:EntityBase
    {
        public string TicariUnvani { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Adresi { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public decimal? Borc { get; set; }
        public decimal? Alacak { get; set; } 
       // public decimal Bakiye { get; set; }
        public ICollection<Lisans> MusteriLisanslar { get; set; }
        public ICollection<YedeklemeHareket> YedeklemeHareketleri { get; set; }
        public ICollection<ModulHareket> ModulHareketleri { get; set; }




    }
}
