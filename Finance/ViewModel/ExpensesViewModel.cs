
//using DAL.Repository;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
  public  class ExpensesViewModel : BaseModel 
    {
        public ObservableCollection<Expenses> ExpensesSource { get; set; }

        public RelayCommand ShowExpenses;

      //  public ExpensesViewModel expensesContext;

        Model1 db = new Model1();

        //in repository
        public ExpensesViewModel()
        {
          //  expensesContext = new ExpensesViewModel();
            ExpensesSource = new ObservableCollection<Expenses>(db.Expenses.ToList());
            ShowExpenses = new RelayCommand(o =>
            {
                db.Expenses.ToList();
            }
            ); //этот список потом надо засунуть в отбражение
        }
    }
}
