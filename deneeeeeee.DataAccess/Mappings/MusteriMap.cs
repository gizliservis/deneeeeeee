using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Mappings
{
  public  class MusteriMap:EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            Property(c => c.MusteriAdi).HasMaxLength(100);
            Property(c => c.MusteriSoyadi).HasMaxLength(100);
            Property(c => c.TicariUnvani).HasMaxLength(150);
            Property(c => c.VergiDairesi).HasMaxLength(50);
            Property(c => c.VergiNo).HasMaxLength(18);
            Property(c => c.Alacak).HasPrecision(18, 2);
            Property(c => c.Borc).HasPrecision(18, 2);
            
        }
    }
}
