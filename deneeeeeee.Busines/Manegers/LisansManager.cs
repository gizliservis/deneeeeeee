using deneeeeeee.Busines.Manegers.Base;
using deneeeeeee.Busines.Services;
using deneeeeeee.DataAccess.Contexts.Yedek;
using deneeeeeee.DataAccess.UnitOfWork;
using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Busines.Manegers
{
    public class LisansManager : BaseManager<Lisans>, ILisansService
    {
        YedekContext context = new YedekContext();
        public LisansManager(IUnitOfWork uow) : base(uow)
        {
        }

        public object LisansListele()
        {
            var lst = context.Musteriler.Join(context.Lisanslar, c => c.Id, c => c.MusteriId, (Musteriler, Lisanslar) => new
            {
                MusteriAdi = Musteriler.MusteriAdi,
                Soyadi = Musteriler.MusteriSoyadi,
                TicariUnvani = Musteriler.TicariUnvani,
                Lisanslar.LisansAdresi,
                Lisanslar.MusteriId,
                Lisanslar.LisansBaslangicYili,
                Lisanslar.LisansBitisTarihi,
                Lisanslar.HatırlatmaTarihi,
                Lisanslar.Aktif
                
            }).ToList();
            return lst;
        }
    }
}
