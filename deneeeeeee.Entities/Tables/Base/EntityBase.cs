using deneeeeeee.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Entities.Tables.Base
{
   public class EntityBase:IEntity
    {
        public Guid Id { get; set; }
        public string Kaydeden { get; set; }
        public DateTime KaydedilmeTarihi { get; set; }
        public string Degistiren { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public string Aciklama { get; set; }

    }
}
