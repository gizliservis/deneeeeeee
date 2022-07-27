using deneeeeeee.Busines.Manegers.Base;
using deneeeeeee.Busines.Services;
using deneeeeeee.DataAccess.UnitOfWork;
using deneeeeeee.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.Busines.Manegers
{
    public class YedeklemeHareketManager : BaseManager<YedeklemeHareket>,IYedeklemeHareketService
    {
        public YedeklemeHareketManager(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
