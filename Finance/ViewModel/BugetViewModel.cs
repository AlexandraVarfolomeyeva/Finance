//using DAL.Repository;
using Finance.Helpers;
using Finance.Model.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Finance.ViewModel
{
  public  class BudgetViewModel : BaseViewModel
    {
        public ObservableCollection<ExpensesPeriod> ExpensesPeriodSource { get; set; }
        
        public ObservableCollection<IncomePeriod> IncomePeriodSource { get; set; }
        public ObservableCollection<ExpensesSum> ExpensesSumSource { get; set; }
        public double TotalIncome, TotalExpenses, Profit;
        public ObservableCollection<IncomeSum> IncomeSumSource { get; set; }
        //public DateTime DateFrom, DateTo;
        //public ExpensesViewModel expensesContext;
        private FinancesDBContext db;

        private string total;
        public string Total
        { 
            get { return total; }
            set { total = value;
                OnPropertyChanged("Total");
            }
        }

        RelayCommand spCommand;
        public RelayCommand SPCommand
        {
            get { return spCommand; }
            set { spCommand = value; }
        }
        int Id;
        //public RelayCommand SPCommand { get; set; }
        //in repository
        public BudgetViewModel(FinancesDBContext dbcontext, int Id)
        {
            db = dbcontext;
            this.Id = Id;
            SPCommand = new RelayCommand(ExecuteSP);
            ExpensesPeriodSource = new ObservableCollection<ExpensesPeriod>();
            IncomePeriodSource = new ObservableCollection<IncomePeriod>();
            ExpensesSumSource = new ObservableCollection<ExpensesSum>();
            IncomeSumSource = new ObservableCollection<IncomeSum>();
        }

        private void ExecuteSP(object parameter)
        {
            try
            {
                ExpensesPeriodSource.Clear();
                ExpensesSumSource.Clear();
                IncomePeriodSource.Clear();
                IncomeSumSource.Clear();



                var stringList = parameter as string[];
                TotalExpenses = 0;
                TotalIncome = 0;
                Profit = 0;
                DateTime DateFrom = DateTime.Parse(stringList[0]);
                DateTime DateTo = DateTime.Parse(stringList[1]);
                // Query the data.
                db.Income.Include(i => i.Source_of_income).Include(i => i.User).Load();
                db.Expenses.Include(i => i.Category).Include(i => i.User).Load();
                db.Category.Load();
                db.Source_of_income.Load();
                System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@beginning", DateFrom);
                System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@beginning", DateFrom);
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@ending", DateTo);
                System.Data.SqlClient.SqlParameter param4 = new System.Data.SqlClient.SqlParameter("@ending", DateTo);
                System.Data.SqlClient.SqlParameter param5 = new System.Data.SqlClient.SqlParameter("@beginning", DateFrom);
                System.Data.SqlClient.SqlParameter param6 = new System.Data.SqlClient.SqlParameter("@ending", DateTo);
                System.Data.SqlClient.SqlParameter param7 = new System.Data.SqlClient.SqlParameter("@beginning", DateFrom);
                System.Data.SqlClient.SqlParameter param8 = new System.Data.SqlClient.SqlParameter("@ending", DateTo);
                System.Data.SqlClient.SqlParameter param9 = new System.Data.SqlClient.SqlParameter("@id", Id);
                System.Data.SqlClient.SqlParameter param10 = new System.Data.SqlClient.SqlParameter("@id", Id);

                var result = db.Database.SqlQuery<ExpensesPeriod>("ExpensesPeriod @beginning, @ending", new object[] { param1, param2 }).ToList();
                foreach (ExpensesPeriod p in result)
                {
                    if (p.User == Id)
                    ExpensesPeriodSource.Add(p);
                }
                var result1 = db.Database.SqlQuery<IncomePeriod>("IncomePeriod @beginning, @ending", new object[] { param3, param4 }).ToList();
                foreach (IncomePeriod p in result1)
                {
                    if (p.User == Id)
                        IncomePeriodSource.Add(p);
                }
                var result2 = db.Database.SqlQuery<IncomeSum>("IncomeSum @beginning, @ending, @id", new object[] { param5, param6, param10}).ToList();
                foreach (IncomeSum p in result2)
                {
                    TotalIncome += p.Sum;
                    IncomeSumSource.Add(p);
                }
                var result3 = db.Database.SqlQuery<ExpensesSum>("ExpensesSum @beginning, @ending, @id", new object[] { param7, param8, param9 }).ToList();
                foreach (ExpensesSum p in result3)
                {
                    TotalExpenses += p.Sum;
                    ExpensesSumSource.Add(p);
                }
                Profit = TotalIncome - TotalExpenses;
               if (Profit>=0) Total = "Расходы составили: "+ TotalExpenses + ". Доходы составили: " + TotalIncome + ". Прибыль: " + Profit + ".";
               else Total = "Расходы составили: " + TotalExpenses + ". Доходы составили: " + TotalIncome + ". Убыток: " + Math.Abs(Profit) + ".";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обнаружена ошибка: " + ex);
            }
         }


    }
}

