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

        //public IncomeRepository inc;
        Model1 db = new Model1();
        DBReposSQL db2 = new DBReposSQL();

        //in repository
        public IncomeViewModel()
        {
          //  expensesContext = new ExpensesViewModel();
            //db2.Incomes.GetList();
            IncomeSource = new ObservableCollection<Income>(db.Income.ToList());
            //ShowIncomes = new RelayCommand(o =>
            //{
            //    new IncomeRepository().GetAll();
            //}
           /* );*/ //этот список потом надо засунуть в отбражение
        }
    }
}
