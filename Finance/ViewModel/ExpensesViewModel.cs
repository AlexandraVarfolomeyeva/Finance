using DAL;
using DAL.Repository;
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

        public ExpensesViewModel expensesContext;

        

        //in repository
        public ExpensesViewModel()
        {
            expensesContext = new ExpensesViewModel();
            ExpensesSource = new ObservableCollection<Expenses>();
            ShowExpenses = new RelayCommand(o =>
            {
                new ExpensesRepository().GetAll();
            }
            ); //этот список потом надо засунуть в отбражение
        }
    }
}
