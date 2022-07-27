using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneeeeeee.DataAccess.Contexts.Yedek
{
    public class YedekConfiguration:DbMigrationsConfiguration<YedekContext>
    {
        public YedekConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
