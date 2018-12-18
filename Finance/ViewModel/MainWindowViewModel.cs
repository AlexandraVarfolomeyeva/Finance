using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
//using DAL.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Finance.ViewModel
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        FinancesDBContext db;
        /// ViewModel для вкладок
        public IncomeViewModel IncomesTabItemVM { set; get; }
        public ExpensesViewModel ExpensesTabItemVM { set; get; }
        public BudgetViewModel BudgetTabItemVM { set; get; }
        public PlanViewModel PlanTabItemVM { set; get; }

        public MainWindowViewModel()
        {
            db = new FinancesDBContext();
            IncomesTabItemVM = new IncomeViewModel(db);
            ExpensesTabItemVM = new ExpensesViewModel(db);
            BudgetTabItemVM = new BudgetViewModel(db);
            PlanTabItemVM = new PlanViewModel(db);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
