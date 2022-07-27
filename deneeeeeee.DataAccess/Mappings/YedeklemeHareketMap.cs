using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Mappings
{
    public class YedeklemeHareketMap:EntityTypeConfiguration<YedeklemeHareket>
    {
        public YedeklemeHareketMap()
        {
            Property(c => c.YedeklemeIslemi).HasMaxLength(60);
            ToTable("YedeklemeHareketleri");
            Property(c => c.YedeklemeIslemi).HasColumnName("YedeklemeIslemi");
            Property(c => c.MusteriId).HasColumnName("MusteriId");
        }
    }
}
