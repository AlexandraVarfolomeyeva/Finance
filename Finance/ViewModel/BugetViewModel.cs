using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
  public  class BudgetViewModel : BaseViewModel
    {
        //stored procedure income - expenses to month/year or smth like that

        private FinancesDBContext db;

        //in repository
        public BudgetViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
        }





    }
}
