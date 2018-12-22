using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
    class EditPlanIncomeViewModel : BaseViewModel
    {
        bool? dr ;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

    FinancesDBContext dbContext;
    public PlanIncome CurrentPlanIncome { get; set; }
    public ObservableCollection<Source_of_income> PlanSourceList { get; set; }
    public RelayCommand ApplyChangesCommand { get; set; }

    public EditPlanIncomeViewModel(FinancesDBContext dbContext, PlanIncome plan, int Id)
    {
        this.dbContext = dbContext;
        PlanSourceList = dbContext.Source_of_income.Local;
        if (plan != null)
        {
            CurrentPlanIncome = plan;
            ApplyChangesCommand = new RelayCommand(UpdatePlanIncome, CanExe);
        }
        else
        {
            CurrentPlanIncome = new PlanIncome();
           
            ApplyChangesCommand = new RelayCommand(AddPlanIncome, CanExe);
        }
        //CurrentPlanIncome.User = dbContext.User.FirstOrDefault(); 
        CurrentPlanIncome.UserId = Id;
    }
        
    private void AddPlanIncome(object parameter)
    {
        DialogResult = true;
        CurrentPlanIncome.Id = 5;
        dbContext.PlanIncome.Add(CurrentPlanIncome);
        dbContext.SaveChanges();
    }

    private void UpdatePlanIncome(object parameter)
    {
        dbContext.SaveChanges();
    }

    public bool CanExe(object parameter)
    {
        return !(CurrentPlanIncome == null) && CurrentPlanIncome.Income != "" && CurrentPlanIncome.Source_of_income != null;
    }
}
}
