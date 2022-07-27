using deneeeeeee.DataAccess.Interfaces.Base;
using deneeeeeee.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<TEntity> Dal<TEntity>() where TEntity:class,IEntity,new();
        bool HasChanges();
        void DetectChanges();
        bool Commit();
    }
}
