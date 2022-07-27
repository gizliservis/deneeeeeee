using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Mappings
{
    public class ModulHareketMap:EntityTypeConfiguration<ModulHareket>
    {
        public ModulHareketMap()
        {
            Property(c => c.Fiyat).HasPrecision(5, 2);
            Property(c => c.Miktar).HasPrecision(8, 2);
            ToTable("ModulHareketleri");
            Property(c => c.ModulId).HasColumnName("ModulId");
            Property(c => c.MusteriId).HasColumnName("MusteriId");
            Property(c => c.Miktar).HasColumnName("Miktar");
            Property(c => c.Fiyat).HasColumnName("Fiyat");


        }
    }
}
