using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
  public  class BugetService : IBugetService
    {
        private IDbRepos db;
        public BugetService(IDbRepos db)
        {
            this.db = db;
        }



    }
}
