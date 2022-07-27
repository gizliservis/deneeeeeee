using deneeeeeee.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Core.Extensions
{
    public static class InculudeMultiple
    {
        public static IQueryable<TEntity> MultipleInculude<TEntity>(this IQueryable<TEntity> query,
         params Expression<Func<TEntity, object>>[] includes) where TEntity : class, IEntity, new()
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            }
            return query;
        }
    }
}
