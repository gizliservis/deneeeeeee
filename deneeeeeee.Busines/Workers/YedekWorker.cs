using deneeeeeee.Busines.Manegers;
using deneeeeeee.Busines.Services;
using deneeeeeee.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Busines.Workers
{
    public class YedekWorker : IWorker
    {
        private IUnitOfWork _uow;
        public ILisansService LisansService { get; set; }
        public IModulService ModulService { get; set; }
        public IModulHareketService ModulHareketService { get; set; }
        public IYedeklemeHareketService YedeklemeHareketService { get; set; }
        public IMusteriService MusteriService { get; set; }
       

        private bool disposedValue;
        public YedekWorker(string connectionString = null)
        {
            _uow = new YedekUnitOfWork(connectionString);
            LisansService = new LisansManager(_uow);
            ModulService = new ModulManager(_uow);
            ModulHareketService = new ModulHareketManager(_uow);
            YedeklemeHareketService = new YedeklemeHareketManager(_uow);
            MusteriService = new MusteriManager(_uow);
            

        }
        public bool Commit()
        {
            return _uow.Commit();
        }

        public void DetectChanges()
        {
            _uow.DetectChanges();
        }

        public bool HasChanges()
        {
            return _uow.HasChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: yönetilen durumu (yönetilen nesneleri) atın
                }

                // TODO: yönetilmeyen kaynakları (yönetilmeyen nesneleri) serbest bırakın ve sonlandırıcıyı geçersiz kılın
                // TODO: büyük alanları null olarak ayarlayın
                disposedValue = true;
            }
        }

        // // TODO: sonlandırıcıyı yalnızca 'Dispose(bool disposing)' içinde yönetilmeyen kaynakları serbest bırakacak kod varsa geçersiz kılın
        // ~RestaurantWorker()
        // {
        //     // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
