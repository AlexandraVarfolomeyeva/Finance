using DAL;
//using DAL.Repository;
using Finance.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Finance.ViewModel
{
    public class IncomeViewModel : BaseViewModel
    {
        //public ObservableCollection<Income> IncomeSource { get; set; }
        private ObservableCollection<Income> incomeSource;
        public ObservableCollection<Income> IncomeSource
        {
            get { return incomeSource; }
            set
            {
                incomeSource = value;
                OnPropertyChanged("IncomeSource");
            }
        }

        //public List<Income> IncomeSource { get; set; }
        public Income SelectedIncome { get; set; }

        RelayCommand addIncomeCommand;
        public RelayCommand AddIncomeCommand
        {
            get { return addIncomeCommand; }
            set { addIncomeCommand = value; }
        }

        RelayCommand addSourceCommand;
        public RelayCommand AddSourceCommand
        {
            get { return addSourceCommand; }
            set { addSourceCommand = value; }
        }

        RelayCommand updateIncomeCommand;
        public RelayCommand UpdateIncomeCommand
        {
            get { return updateIncomeCommand; }
            set { updateIncomeCommand = value; }
        }
        RelayCommand deleteIncomeCommand;
        public RelayCommand DeleteIncomeCommand
        {
            get { return deleteIncomeCommand; }
            set { deleteIncomeCommand = value; }
        }

        //public ExpensesViewModel expensesContext;

        private FinancesDBContext db;
        //DBReposSQL db2 = new DBReposSQL();
        int Id;
        //in repository
        public IncomeViewModel(FinancesDBContext dbcontext, int Id)
        {
            db = dbcontext;
            this.Id = Id;
            LoadIncomes();
            AddIncomeCommand = new RelayCommand(AddIncome);
            UpdateIncomeCommand = new RelayCommand(UpdateIncome, CanExecute);
            DeleteIncomeCommand = new RelayCommand(DeleteIncome, CanExecute);
            addSourceCommand = new RelayCommand(AddSource);
        }

        private void LoadIncomes()
        {
            db.Income.Include(i => i.Source_of_income).Include(i => i.User).Load();
            IncomeSource = new ObservableCollection<Income>(db.Income.Where(i => i.User.Id == Id).ToList());
        }

        public void AddIncome(object parameter)
        {
            Window window = new View.EditIncome();
            window.DataContext = new EditIncomesViewModel(db, null, Id);
            window.Title = "Добавление";
            window.ShowDialog();
            IncomeSource = new ObservableCollection<Income>(db.Income.Where(i => i.User.Id == Id).ToList());
        }

        public void AddSource(object parameter)
        {
            Window window = new View.AddSource();
            window.DataContext = new AddSourceViewModel(db);
            //window.Title = "Добавление";
            window.ShowDialog();
        }


        public void UpdateIncome(object parameter)
        {
            Window window = new View.EditIncome();
            window.DataContext = new EditIncomesViewModel(db, SelectedIncome, Id);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void DeleteIncome(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить доход {SelectedIncome.Sum} ({SelectedIncome.Source_of_income.Name}) от {SelectedIncome.Date}?"))
            {
                db.Income.Local.Remove(SelectedIncome);
                IncomeSource.Remove(SelectedIncome);
                db.SaveChanges();
            }
        }

        public bool CanExecute(object parameter)
        {
            return SelectedIncome != null;
        }



    }
}
