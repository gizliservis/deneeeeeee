using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Entities.Tables
{
    public class Lisans:EntityBase
    {
        public string LisansAdresi { get; set; }
        public string LisansNo { get; set; }
        public DateTime LisansBaslangicYili { get; set; }
        public DateTime? LisansBitisTarihi{ get; set; }
        public DateTime? HatırlatmaTarihi { get; set; }
        public string LisansTuru { get; set; }
        public Guid MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }
        public bool Aktif { get; set; }
    }
}
