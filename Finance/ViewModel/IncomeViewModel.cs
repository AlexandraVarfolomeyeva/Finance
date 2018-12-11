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
   public class IncomeViewModel : BaseModel
    {
        public ObservableCollection<Income> IncomeSource { get; set; }

        public RelayCommand ShowIncomes;

        public ExpensesViewModel expensesContext;

        public IncomeRepository inc;

        //in repository
        public IncomeViewModel()
        {
            expensesContext = new ExpensesViewModel();
            IncomeSource = new ObservableCollection<Income>(inc.GetAll());
            //ShowIncomes = new RelayCommand(o =>
            //{
            //    new IncomeRepository().GetAll();
            //}
           /* );*/ //этот список потом надо засунуть в отбражение
        }
    }
}
