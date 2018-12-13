using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
    class EditPlanViewModel : BaseViewModel
    {
        bool? dr ;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

    FinancesDBContext dbContext;
    public Plan CurrentPlan { get; set; }
    public ObservableCollection<Source_of_income> PlanSourceList { get; set; }
    public RelayCommand ApplyChangesCommand { get; set; }

    public EditPlanViewModel(FinancesDBContext dbContext, Plan plan)
    {
        this.dbContext = dbContext;
        PlanSourceList = dbContext.Source_of_income.Local;
        if (plan != null)
        {
            CurrentPlan = plan;
            ApplyChangesCommand = new RelayCommand(UpdatePlan, CanExe);
        }
        else
        {
            CurrentPlan = new Plan();
           
            ApplyChangesCommand = new RelayCommand(AddPlan, CanExe);
        }
        CurrentPlan.User = dbContext.User.FirstOrDefault();
    }

    private void AddPlan(object parameter)
    {
        DialogResult = true;
        dbContext.Plan.Add(CurrentPlan);
        dbContext.SaveChanges();
    }

    private void UpdatePlan(object parameter)
    {
        dbContext.SaveChanges();
    }

    public bool CanExe(object parameter)
    {
        return !(CurrentPlan == null) && CurrentPlan.Income > 0 && CurrentPlan.Source_of_income != null;
    }
}
}
