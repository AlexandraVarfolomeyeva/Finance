//using DAL.Repository;
using Finance.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;

namespace Finance.ViewModel
{
  public  class BudgetViewModel : BaseViewModel
    {
        //public ObservableCollection<Expenses> ExpensesPeriodSource { get; set; }
        public ObservableCollection<Income> IncomePeriodSource { get; set; }
        DateTime DateFrom, DateTo;
        public ExpensesViewModel expensesContext;
        private FinancesDBContext db;

        RelayCommand spCommand;
        public RelayCommand SPCommand
        {
            get { return spCommand; }
            set { spCommand = value; }
        }

        //public RelayCommand SPCommand { get; set; }
        //in repository
        public BudgetViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
            SPCommand = new RelayCommand(ExecuteSP, CanExe);
        }

        private void ExecuteSP(object parameter)
        {
            db.Income.Include(i => i.Source_of_income).Include(i => i.User).Load();
            db.Expenses.Include(i => i.Category).Include(i => i.User).Load();
        
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@beginning", DateFrom);
            System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@ending", DateTo);
            var ExpensesPeriodSource = db.Database.SqlQuery<Expenses>("ExpensesPeriod @beginning, @ending", new object[] { param1, param2});
        }


        private bool CanExe(object parameter)
        {
            return true; //если таблицы не пустые?
        }
 

    }
}

