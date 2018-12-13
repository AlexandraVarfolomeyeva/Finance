using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
    public class EditExpensesViewModel : BaseViewModel
    {
        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        FinancesDBContext dbContext;
        public Expenses CurrentExpenses { get; set; }
        public ObservableCollection<Source_of_income> ExpensesSourceList { get; set; }
        public RelayCommand ApplyChangesCommand { get; set; }

        public EditExpensesViewModel(FinancesDBContext dbContext, Expenses expenses)
        {
            this.dbContext = dbContext;
            ExpensesSourceList = dbContext.Source_of_income.Local;
            if (expenses != null)
            {
                CurrentExpenses = expenses;
                ApplyChangesCommand = new RelayCommand(UpdateExpenses, CanExe);
            }
            else
            {
                CurrentExpenses = new Expenses();
                CurrentExpenses.Date = DateTime.Now;
                ApplyChangesCommand = new RelayCommand(AddExpenses, CanExe);
            }
            CurrentExpenses.User = dbContext.User.FirstOrDefault();
        }

        private void AddExpenses(object parameter)
        {
            DialogResult = true;
            dbContext.Expenses.Add(CurrentExpenses);
            dbContext.SaveChanges();
        }

        private void UpdateExpenses(object parameter)
        {
            dbContext.SaveChanges();
        }

        public bool CanExe(object parameter)
        {
            return !(CurrentExpenses == null) && CurrentExpenses.Sum > 0 && CurrentExpenses.Category != null;
        }
    }
}
