
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
        public ObservableCollection<Plan> PlanSource { get; set; }
        public ObservableCollection<PlanIncome> PlanIncomeSource { get; set; }
        public ObservableCollection<Purchase> PurchaseSource { get; set; }
        public Plan SelectedPlan { get; set; }
        public PlanIncome SelectedPlanIncome { get; set; }
        public Purchase SelectedPurchase { get; set; }

    RelayCommand addPlanCommand;
        public RelayCommand AddPlanCommand
        {
            get { return addPlanCommand; }
            set { addPlanCommand = value; }
        }

        RelayCommand addPurchaseCommand;
        public RelayCommand AddPurchaseCommand
        {
            get { return addPurchaseCommand; }
            set { addPurchaseCommand = value; }
        }



        RelayCommand updatePlanCommand;
        public RelayCommand UpdatePlanCommand
        {
            get { return updatePlanCommand; }
            set { updatePlanCommand = value; }
        }

        RelayCommand deletePlanCommand;
        public RelayCommand DeletePlanCommand
        {
            get { return deletePlanCommand; }
            set { deletePlanCommand = value; }
        }

        RelayCommand deletePurchaseCommand;
        public RelayCommand DeletePurchaseCommand
        {
            get { return deletePurchaseCommand; }
            set { deletePurchaseCommand = value; }
        }

        public PlanViewModel planContext;
        private FinancesDBContext db;
        //DBReposSQL db2 = new DBReposSQL();

        //in repository
        public PlanViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
            LoadPlan();
            
            AddPlanCommand = new RelayCommand(AddPlan);
            UpdatePlanCommand = new RelayCommand(UpdatePlan, CanExecutePlan);
            DeletePlanCommand = new RelayCommand(DeletePlan, CanExecutePlan);

            LoadPurchase();
            AddPurchaseCommand = new RelayCommand(AddPurchase);
            DeletePurchaseCommand = new RelayCommand(DeletePurchase, CanExecutePurchase);
        }

        private void LoadPlan()
        {
            db.Plan.Include(i => i.Category).Include(i => i.User).Include(i => i.Source_of_income).Load();
            PlanSource = db.Plan.Local;

            db.PlanIncome.Include(i => i.User).Load();
            PlanIncomeSource = db.PlanIncome.Local;
        }

        private void LoadPurchase()
        {
            db.Purchase.Include(i => i.User).Load();
            PurchaseSource = db.Purchase.Local;
        }

        public void AddPlan(object parameter)
        {
            Window window = new View.EditPlan();
            window.DataContext = new EditPlanViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }

        public void AddPurchase(object parameter)
        {
            Window window = new View.EditPurchase();
            window.DataContext = new EditPlanViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }

        public void UpdatePlan(object parameter)
        {
            Window window = new View.EditPurchase();
            window.DataContext = new EditPlanViewModel(db, SelectedPlan);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void DeletePlan(Object parameter)
        {

            if (ConfirmDialog.Confirm($"Удалить план {SelectedPlan.Income} {SelectedPlan.Source_of_income} ?"))
            {
                PlanSource.Remove(SelectedPlan);
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


        public bool CanExecutePlan(object parameter)
        {
            return SelectedPlan != null;

        }

        public bool CanExecutePurchase(object parameter)
        {
            return SelectedPurchase != null;
        }
    }
}
