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
    public class ModulHareketDal : Repository<ModulHareket>, IModulHareketDal
    {
        public ModulHareketDal(DbContext context) : base(context)
        {
        }
    }
}
