using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Mappings
{
    public class LisansMap : EntityTypeConfiguration<Lisans>
    {
        public LisansMap()
        {
            Property(c => c.LisansAdresi).HasMaxLength(250);
            Property(c => c.LisansNo).HasMaxLength(25);
            ToTable("Lisanslar");
            
            Property(c => c.LisansAdresi).HasColumnName("LisanAdresi");
            Property(c => c.LisansBaslangicYili).HasColumnName("LisansBaslangicYili");
            Property(c => c.LisansBitisTarihi).HasColumnName("LisansBitisTarihi");
            Property(c => c.HatırlatmaTarihi).HasColumnName("HatırlatmaTarihi");
            Property(c => c.MusteriId).HasColumnName("MusteriId");
            Property(c => c.Aktif).HasColumnName("Aktif");
        }
    }
}
