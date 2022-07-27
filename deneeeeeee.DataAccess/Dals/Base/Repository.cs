using deneeeeeee.Core.Extensions;
using deneeeeeee.DataAccess.Interfaces;
using deneeeeeee.DataAccess.Interfaces.Base;
using deneeeeeee.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Dals.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context ;
        }
        private bool disposedValue;

        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
        }

        public void AddOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void AddOrUpdate(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().AddOrUpdate(entity);
            }
        }
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;

            }
        }



        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;

        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>().Where(filter));
        }

        public bool Exist(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Any(filter);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return _context.Set<TEntity>().MultipleInculude(includes).SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return filter == null
                ? _context.Set<TEntity>().MultipleInculude(includes).AsNoTracking().ToList()
                : _context.Set<TEntity>().MultipleInculude(includes).Where(filter).AsNoTracking().ToList();
        }

        public bool HasChanges()
        {

            return _context.ChangeTracker.Entries<TEntity>().Any();
        }

        public void Load(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter == null)
            {
                try
                {
                    _context.Set<TEntity>().MultipleInculude(includes).Load();
                }
                catch (Exception e)
                {
                 Console.WriteLine(e.Message);
                }
                
            }
            else
            {
                _context.Set<TEntity>().MultipleInculude(includes).Where(filter).Load();
            }

        }

        public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TEntity>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            return filter == null
                ? _context.Set<TEntity>().MultipleInculude(includes).Select(selector)
                : _context.Set<TEntity>().MultipleInculude(includes).Where(filter).Select(selector);
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            return filter == null
                ? _context.Set<TEntity>().MultipleInculude(includes).Select(selector)
                : _context.Set<TEntity>().MultipleInculude(includes).Where(filter).Select(selector);


        }
        public BindingList<TEntity> BindingList()
        {
            return _context.Set<TEntity>().Local.ToBindingList();
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
        // ~Repository()
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

        public void EntityStateChange(Expression<Func<TEntity, bool>> filter, EntityState state)
        {
            foreach (var entity in _context.Set<TEntity>().Local.AsQueryable().Where(filter).ToList())
            {
                _context.Entry(entity).State = state;
            }
        }

        public void EntityStateChange(TEntity entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

        public void EntityStateChange(IEnumerable<TEntity> entities, EntityState state)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = state;
            }
        }

        public bool HasChages()
        {
            throw new NotImplementedException();
        }


    }
}
