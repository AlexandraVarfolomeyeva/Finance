
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
    public class PlanViewModel : BaseViewModel
    {
        public ObservableCollection<PlanExpenses> PlanExpensesSource { get; set; }
        public ObservableCollection<PlanIncome> PlanIncomeSource { get; set; }
        public ObservableCollection<Purchase> PurchaseSource { get; set; }
        public PlanExpenses SelectedPlanExpenses { get; set; }
        public PlanIncome SelectedPlanIncome { get; set; }
        public Purchase SelectedPurchase { get; set; }

    RelayCommand addPlanIncomeCommand;
        public RelayCommand AddPlanIncomeCommand
        {
            get { return addPlanIncomeCommand; }
            set { addPlanIncomeCommand = value; }
        }

        RelayCommand addPlanExpensesCommand;
        public RelayCommand AddPlanExpensesCommand
        {
            get { return addPlanExpensesCommand; }
            set { addPlanExpensesCommand = value; }
        }

        RelayCommand addPurchaseCommand;
        public RelayCommand AddPurchaseCommand
        {
            get { return addPurchaseCommand; }
            set { addPurchaseCommand = value; }
        }



        RelayCommand updatePlanIncomeCommand;
        public RelayCommand UpdatePlanIncomeCommand
        {
            get { return updatePlanIncomeCommand; }
            set { updatePlanIncomeCommand = value; }
        }

        RelayCommand updatePlanExpensesCommand;
        public RelayCommand UpdatePlanExpensesCommand
        {
            get { return updatePlanExpensesCommand; }
            set { updatePlanExpensesCommand = value; }
        }

        RelayCommand deletePlanIncomeCommand;
        public RelayCommand DeletePlanIncomeCommand
        {
            get { return deletePlanIncomeCommand; }
            set { deletePlanIncomeCommand = value; }
        }

        RelayCommand deletePlanExpensesCommand;
        public RelayCommand DeletePlanExpensesCommand
        {
            get { return deletePlanExpensesCommand; }
            set { deletePlanExpensesCommand = value; }
        }


        RelayCommand deletePurchaseCommand;
        public RelayCommand DeletePurchaseCommand
        {
            get { return deletePurchaseCommand; }
            set { deletePurchaseCommand = value; }
        }

        public PlanViewModel planContext;
        private FinancesDBContext db;

        //in repository
        public PlanViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
            LoadPlan();
            
            AddPlanIncomeCommand = new RelayCommand(AddPlanIncome);
            UpdatePlanIncomeCommand = new RelayCommand(UpdatePlanIncome, CanExecutePlanIncome);
            DeletePlanIncomeCommand = new RelayCommand(DeletePlanIncome, CanExecutePlanIncome);

            AddPlanExpensesCommand = new RelayCommand(AddPlanExpenses);
            UpdatePlanExpensesCommand = new RelayCommand(UpdatePlanExpenses, CanExecutePlanExpenses);
            DeletePlanExpensesCommand = new RelayCommand(DeletePlanExpenses, CanExecutePlanExpenses);

            LoadPurchase();
            AddPurchaseCommand = new RelayCommand(AddPurchase);
            DeletePurchaseCommand = new RelayCommand(DeletePurchase, CanExecutePurchase);
        }

        private void LoadPlan()
        {
            db.PlanIncome.Include(i => i.User).Include(i => i.Source_of_income).Load();
            PlanIncomeSource = db.PlanIncome.Local;

            db.PlanExpenses.Include(i => i.User).Include(i => i.Category).Load();
            PlanExpensesSource = db.PlanExpenses.Local;
        }

        private void LoadPurchase()
        {
            db.Purchase.Include(i => i.User).Load();
            PurchaseSource = db.Purchase.Local;
        }

        public void AddPlanIncome(object parameter)
        {
            Window window = new View.EditPlanIncome();
            window.DataContext = new EditPlanIncomeViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }

        public void AddPlanExpenses(object parameter)
        {
            Window window = new View.EditPlanExpenses();
            window.DataContext = new EditPlanExpensesViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }


        public void AddPurchase(object parameter)
        {
            Window window = new View.EditPurchase();
            window.DataContext = new EditPurchaseViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }

        public void UpdatePlanIncome(object parameter)
        {
            Window window = new View.EditPlanIncome();
            window.DataContext = new EditPlanIncomeViewModel(db, SelectedPlanIncome);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void UpdatePlanExpenses(object parameter)
        {
            Window window = new View.EditPlanExpenses();
            window.DataContext = new EditPlanExpensesViewModel(db, SelectedPlanExpenses);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void DeletePlanIncome(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить план {SelectedPlanIncome.Income} {SelectedPlanIncome.Source_of_income.Name} ?"))
            {
                PlanIncomeSource.Remove(SelectedPlanIncome);
                db.SaveChanges();
            }
        }

        public void DeletePlanExpenses(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить план {SelectedPlanExpenses.Expenses} {SelectedPlanExpenses.Category.Category_name} ?"))
            {
                PlanExpensesSource.Remove(SelectedPlanExpenses);
                db.SaveChanges();
            }
        }

        public void DeletePurchase(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить покупку {SelectedPurchase.Name}?"))
            {
                PurchaseSource.Remove(SelectedPurchase);
                db.SaveChanges();
            }
        }


        public bool CanExecutePlanIncome(object parameter)
        {
            return SelectedPlanIncome != null;
        }

        public bool CanExecutePlanExpenses(object parameter)
        {
            return SelectedPlanExpenses != null;
        }

        public bool CanExecutePurchase(object parameter)
        {
            return SelectedPurchase != null;
        }
    }
}
