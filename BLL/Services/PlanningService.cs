using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class PlanningService : IPlanningService
    {
        private IDbRepos db;
        public PlanningService(IDbRepos db)
        {
            this.db = db;
        }




    }
}
