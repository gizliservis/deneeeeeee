using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Mappings
{
    public class ModulMap:EntityTypeConfiguration<Modul>
    {
        public ModulMap()
        {
            Property(c => c.Adi).HasMaxLength(70);
            Property(c => c.Icerik).HasMaxLength(150);
            Property(c => c.Fiyati).HasPrecision(5,2);
            ToTable("Moduller");
            Property(c => c.Adi).HasColumnName("Adi");
            Property(c => c.Icerik).HasColumnName("Icerik");
            Property(c => c.Fiyati).HasColumnName("Fiyati");
        }
    }
}
