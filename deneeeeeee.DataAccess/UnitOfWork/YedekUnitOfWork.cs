using deneeeeeee.Core.Functions;
using deneeeeeee.DataAccess.Contexts.Yedek;
using deneeeeeee.DataAccess.Dals;
using deneeeeeee.DataAccess.Dals.Base;
using deneeeeeee.DataAccess.Functions;
using deneeeeeee.DataAccess.Interfaces;
using deneeeeeee.DataAccess.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.UnitOfWork
{
    public class YedekUnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly YedekContext _context;
        public ILisansDal LisansDal { get; set; }
        public IModulDal ModulDal { get; set; }
        public IModulHareketDal ModulHareketDal { get; set; }
        public IMusteriDal MusteriDal { get; set; }
        public IYedeklemeHareketDal YedeklemeHareketDal { get; set; }

        public YedekUnitOfWork(string connectionString=null)
        {
            if (connectionString==null)
            {
                _context = new YedekContext(ConnectionStringInfo.Get());
            }
            else
            {
                _context = new YedekContext(connectionString);
            }
           
            LisansDal= new LisansDal(_context);
            ModulDal=new ModulDal(_context);
            ModulHareketDal=new ModulHareketDal(_context);
            MusteriDal=new MusteriDal(_context);
            YedeklemeHareketDal = new YedeklemeHareketDal(_context);
        }

        public bool Commit()
        {
            EntityBaseInfo.Add(_context);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        IRepository<TEntity> IUnitOfWork.Dal<TEntity>()
        {
            return new Repository<TEntity>(_context);
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
        // ~YedekUnitOfWork()
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
