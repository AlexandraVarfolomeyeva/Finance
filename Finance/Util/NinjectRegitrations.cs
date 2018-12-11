using BLL;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Util
{
    public class NinjectRegitrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IOffenceService>().To<OffenceService>();
            Bind<IPlanningService>().To<PlanningService>();
            Bind<IDbCrud>().To<DbDataOperation>();
        }
    }
}
