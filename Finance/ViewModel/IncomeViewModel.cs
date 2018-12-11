using DAL;
using DAL.Repository;
using Finance.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;

namespace Finance.ViewModel
{
    public class IncomeViewModel : BaseViewModel
    {
        public ObservableCollection<Income> IncomeSource { get; set; }
        public Income SelectedIncome { get; set; }

        RelayCommand addIncomeCommand;
        public RelayCommand AddIncomeCommand
        {
            get { return addIncomeCommand; }
            set { addIncomeCommand = value; }
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

        public ExpensesViewModel expensesContext;

        //public IncomeRepository inc;
        private FinancesDBContext db;
        DBReposSQL db2 = new DBReposSQL();

        //in repository
        public IncomeViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
            LoadIncomes();
            AddIncomeCommand = new RelayCommand(AddIncome);
            UpdateIncomeCommand = new RelayCommand(UpdateIncome, CanExecute);
            DeleteIncomeCommand = new RelayCommand(DeleteIncome, CanExecute);

            //db2.Incomes.GetList();
            //IncomeSource = new ObservableCollection<Income>(db.Income.ToList());
            //ShowIncomes = new RelayCommand(o =>
            //{
            //    new IncomeRepository().GetAll();
            //}
            /* );*/ //этот список потом надо засунуть в отбражение
        }

        private void LoadIncomes()
        {
            db.Income.Include(i => i.Source_of_income).Include(i => i.User).Load();
            IncomeSource = db.Income.Local;
        }

        public void AddIncome(object parameter)
        {
            Window window = new View.EditIncome();
            window.DataContext = new EditIncomesViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }
        public void UpdateIncome(object parameter)
        {
            Window window = new View.EditIncome();
            window.DataContext = new EditIncomesViewModel(db, SelectedIncome);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void DeleteIncome(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить доход {SelectedIncome.Sum} ({SelectedIncome.Source_of_income.Name}) от {SelectedIncome.Date}?"))
            {
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
