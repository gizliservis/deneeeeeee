using deneeeeeee.DataAccess.Dals.Base;
using deneeeeeee.DataAccess.Interfaces;
using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Dals
{
    public class YedeklemeHareketDal : Repository<YedeklemeHareket>, IYedeklemeHareketDal
    {
        public YedeklemeHareketDal(DbContext context) : base(context)
        {
        }
    }
}
