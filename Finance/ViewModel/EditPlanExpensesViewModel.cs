using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
    class EditPlanExpensesViewModel : BaseViewModel
    {
     
            bool? dr;
            public bool? DialogResult { get { return dr; } set { dr = value; } }

            FinancesDBContext dbContext;
            public PlanExpenses CurrentPlanExpenses { get; set; }
            public ObservableCollection<Category> PlanCategoryList { get; set; }
            public RelayCommand ApplyChangesCommand { get; set; }

            public EditPlanExpensesViewModel(FinancesDBContext dbContext, PlanExpenses plan, int Id)
            {
                this.dbContext = dbContext;
                PlanCategoryList = dbContext.Category.Local;
                if (plan != null)
                {
                CurrentPlanExpenses = plan;
                    ApplyChangesCommand = new RelayCommand(UpdatePlanExpenses, CanExe);
                }
                else
                {
                CurrentPlanExpenses = new PlanExpenses();

                    ApplyChangesCommand = new RelayCommand(AddPlanExpenses, CanExe);
                }
            //CurrentPlanExpenses.User = dbContext.User.FirstOrDefault();
            CurrentPlanExpenses.UserId = Id;
            }

            private void AddPlanExpenses(object parameter)
            {
                DialogResult = true;
        
             
                dbContext.PlanExpenses.Add(CurrentPlanExpenses);
                dbContext.SaveChanges();
            }

            private void UpdatePlanExpenses(object parameter)
            {
                dbContext.SaveChanges();
            }

            public bool CanExe(object parameter)
            {
                return !(CurrentPlanExpenses == null) && CurrentPlanExpenses.Expenses != "" && CurrentPlanExpenses.Category != null;
            }
    }
}


