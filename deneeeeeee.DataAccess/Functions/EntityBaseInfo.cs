using deneeeeeee.Entities.Tables.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Functions
{
    internal class EntityBaseInfo
    {
        public static void Add(DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                EntityBase changingEntity = (EntityBase)entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                       
                        changingEntity.KaydedilmeTarihi = DateTime.Now;
                        changingEntity.Kaydeden = "İsmail Cem Babaoğlu";
                        break;
                    case EntityState.Modified:
                        changingEntity.DegistirmeTarihi = DateTime.Now;
                        changingEntity.Degistiren = "İsmail Cem Babaoğlu";
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
