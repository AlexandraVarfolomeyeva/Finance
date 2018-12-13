
using DAL.Repository;
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
        public Plan SelectedPlan { get; set; }

        RelayCommand addPlanCommand;
        public RelayCommand AddPlanCommand
        {
            get { return addPlanCommand; }
            set { addPlanCommand = value; }
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

        //public PlanViewModel planContext;
        private FinancesDBContext db;
        DBReposSQL db2 = new DBReposSQL();

        //in repository
        public PlanViewModel(FinancesDBContext dbcontext)
        {
            db = dbcontext;
            LoadPlan();
            AddPlanCommand = new RelayCommand(AddPlan);
            UpdatePlanCommand = new RelayCommand(UpdatePlan, CanExecute);
            DeletePlanCommand = new RelayCommand(DeletePlan, CanExecute);
        }

        private void LoadPlan()
        {
            //db.Plan.Include(i => i.Category).Include(i => i.User).Include(i => i.Source_of_income).Load();
            PlanSource = db.Plan.Local;
        }

        public void AddPlan(object parameter)
        {
            Window window = new View.EditPlan();
            window.DataContext = new EditPlanViewModel(db, null);
            window.Title = "Добавление";
            window.ShowDialog();
        }
        public void UpdatePlan(object parameter)
        {
            Window window = new View.EditPlan();
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

        public bool CanExecute(object parameter)
        {
            return SelectedPlan != null;
        }
    }
}
