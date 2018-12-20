
//using DAL.Repository;
using DAL;
//using DAL.Repository;
using Finance.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;

namespace Finance.ViewModel
{
  public  class ExpensesViewModel : BaseViewModel 
    {
        public ObservableCollection<Expenses> ExpensesSource { get; set; }
        public Expenses SelectedExpenses { get; set; }

        RelayCommand addExpensesCommand;
        public RelayCommand AddExpensesCommand
        {
            get { return addExpensesCommand; }
            set { addExpensesCommand = value; }
        }

        RelayCommand updateExpensesCommand;
        public RelayCommand UpdateExpensesCommand
        {
            get { return updateExpensesCommand; }
            set { updateExpensesCommand = value; }
        }
        RelayCommand deleteExpensesCommand;
        public RelayCommand DeleteExpensesCommand
        {
            get { return deleteExpensesCommand; }
            set { deleteExpensesCommand = value; }
        }

        public ExpensesViewModel expensesContext;
        private FinancesDBContext db;
        //DBReposSQL db2 = new DBReposSQL();

        //in repository
        public ExpensesViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
            LoadExpenses();
            AddExpensesCommand = new RelayCommand(AddExpenses);
            UpdateExpensesCommand = new RelayCommand(UpdateExpenses, CanExecute);
            DeleteExpensesCommand = new RelayCommand(DeleteExpenses, CanExecute);
        }

        private void LoadExpenses()
        {
            db.Expenses.Include(i => i.Category).Include(i => i.User).Load();
            ExpensesSource = db.Expenses.Local;
        }

        public void AddExpenses(object parameter)
        {
            Window window = new View.EditExpenses();
            window.DataContext = new EditExpensesViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }
        public void UpdateExpenses(object parameter)
        {
            Window window = new View.EditExpenses();
            window.DataContext = new EditExpensesViewModel(db, SelectedExpenses);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void DeleteExpenses(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить покупку {SelectedExpenses.Name} {SelectedExpenses.Sum} ({SelectedExpenses.Category.Name}) от {SelectedExpenses.Date}?"))
            {
               ExpensesSource.Remove(SelectedExpenses);
                db.SaveChanges();
            }
        }

        public bool CanExecute(object parameter)
        {
            return SelectedExpenses != null;
        }


    }
}
