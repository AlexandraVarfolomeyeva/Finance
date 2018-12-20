//using DAL.Repository;
using Finance.Helpers;
using Finance.Model.Entities;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;

namespace Finance.ViewModel
{
  public  class BudgetViewModel : BaseViewModel
    {
        public ObservableCollection<ExpensesPeriod> ExpensesPeriodSource { get; set; }
        
        public ObservableCollection<Income> IncomePeriodSource { get; set; }
        //public DateTime DateFrom, DateTo;
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
            SPCommand = new RelayCommand(ExecuteSP);
        }

        private void ExecuteSP(object parameter)
        {
            try
            {
                var stringList = parameter as string[];

                DateTime DateFrom = DateTime.Parse(stringList[0]);
                DateTime DateTo = DateTime.Parse(stringList[1]);
                // Query the data.
                db.Income.Include(i => i.Source_of_income).Include(i => i.User).Load();
                db.Expenses.Include(i => i.Category).Include(i => i.User).Load();
                db.Category.Load();
                System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@beginning", DateFrom);
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@ending", DateTo);
                var result = db.Database.SqlQuery<ExpensesPeriod>("ExpensesPeriod @beginning, @ending", new object[] { param1, param2 });
                foreach (ExpensesPeriod p in result)
                {
                    ExpensesPeriodSource.Add(p);
                }

    }
            catch (Exception ex)
            {
                MessageBox.Show("Обнаружена ошибка: " + ex);
            }
         }


    }
}

