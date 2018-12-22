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
        public BudgetViewModel BugetTabItemVM { set; get; }
        public PlanViewModel PlanTabItemVM { set; get; }

        public MainWindowViewModel(FinancesDBContext db, int Id)
        {
            //db = new FinancesDBContext();
            this.db = db;
            IncomesTabItemVM = new IncomeViewModel(db, Id);
            ExpensesTabItemVM = new ExpensesViewModel(db, Id);
            BugetTabItemVM = new BudgetViewModel(db,Id);
            PlanTabItemVM = new PlanViewModel(db, Id);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
