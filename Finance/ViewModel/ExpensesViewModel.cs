
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
        //public ObservableCollection<Expenses> ExpensesSource { get; set; }

        private ObservableCollection<Expenses> expensesSource;
        public ObservableCollection<Expenses> ExpensesSource
        {
            get { return expensesSource; }
            set
            {
                expensesSource = value;
                OnPropertyChanged("ExpensesSource");
            }
        }

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
        int Id;
        //in repository
        public ExpensesViewModel(FinancesDBContext dbcontext, int Id)
        {
            db = dbcontext;
            this.Id = Id;
            LoadExpenses();
            AddExpensesCommand = new RelayCommand(AddExpenses);
            UpdateExpensesCommand = new RelayCommand(UpdateExpenses, CanExecute);
            DeleteExpensesCommand = new RelayCommand(DeleteExpenses, CanExecute);
        }

        private void LoadExpenses()
        {
            db.Expenses.Include(i => i.Category).Include(i => i.User).Load();
            //ExpensesSource = db.Expenses.Local;
            ExpensesSource = new ObservableCollection<Expenses>(db.Expenses.Where(i => i.User.Id == Id).ToList());
        }

        public void AddExpenses(object parameter)
        {
            Window window = new View.EditExpenses();
            window.DataContext = new EditExpensesViewModel(db, null, Id);
            window.Title = "Добавление";
            window.ShowDialog();
            ExpensesSource = new ObservableCollection<Expenses>(db.Expenses.Where(i => i.User.Id == Id).ToList());

        }
        public void UpdateExpenses(object parameter)
        {
            Window window = new View.EditExpenses();
            window.DataContext = new EditExpensesViewModel(db, SelectedExpenses, Id);
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
