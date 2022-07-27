using deneeeeeee.DataAccess.Contexts.Base;
using deneeeeeee.DataAccess.Mappings;
using deneeeeeee.Entities.Tables;
using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Contexts.Yedek
{
    public class YedekContext : BaseContext<YedekContext>
    {
        public YedekContext()
        {
        }

        public YedekContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YedekContext,YedekConfiguration>());
        }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Modul> Moduller { get; set; }
        public DbSet<ModulHareket> ModulHareketler { get; set; }
        public DbSet<YedeklemeHareket> YedeklemmeHareketler { get; set; }
        public DbSet<Lisans> Lisanslar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Types<EntityBase>().Configure(c =>
            {
                c.HasKey(e => e.Id);
                c.Property(e => e.Kaydeden).HasMaxLength(100);
                c.Property(e => e.Degistiren).HasMaxLength(100);
                c.Property(e => e.Aciklama).HasMaxLength(300);
                c.Property(e => e.Id).HasColumnName("Id");
                c.Property(e => e.Kaydeden).HasColumnName("Kaydeden");
                c.Property(e => e.DegistirmeTarihi).HasColumnName("DegistirmeTarihi");
                c.Property(e => e.Degistiren).HasColumnName("Degistiren");
                c.Property(e => e.KaydedilmeTarihi).HasColumnName("KaydedilmeTarihi");
                c.Property(e => e.Aciklama).HasColumnName("Aciklama");
            });
            modelBuilder.Entity<Lisans>().HasRequired(c => c.Musteri).WithMany(c => c.MusteriLisanslar).
                HasForeignKey(c=>c.MusteriId);
            modelBuilder.Entity<ModulHareket>().HasRequired(c => c.Modul).WithMany(c => c.ModulHareketleri).
                HasForeignKey(c => c.ModulId);
            modelBuilder.Entity<ModulHareket>().HasRequired(c => c.Musteri).WithMany(c => c.ModulHareketleri).
                HasForeignKey(c => c.MusteriId);
            modelBuilder.Entity<YedeklemeHareket>().HasRequired(c => c.Musteri).WithMany(c => c.YedeklemeHareketleri).
                HasForeignKey(c => c.MusteriId);

            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new ModulMap());
            modelBuilder.Configurations.Add(new ModulHareketMap());
            modelBuilder.Configurations.Add(new LisansMap());
            modelBuilder.Configurations.Add(new YedeklemeHareketMap());
        }


    }
}
