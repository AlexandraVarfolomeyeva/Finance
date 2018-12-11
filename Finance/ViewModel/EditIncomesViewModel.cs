using DAL;
using Finance.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
    public class EditIncomesViewModel: BaseViewModel
    {
        bool? dr ;
        public bool? DialogResult { get { return dr; } set {dr=value; } }

        FinancesDBContext dbContext;
        public Income CurrentIncome { get; set; }
        public ObservableCollection<Source_of_income> IncomeSourceList { get; set; }
        public RelayCommand ApplyChangesCommand { get; set; }

        public EditIncomesViewModel(FinancesDBContext dbContext, Income income)
        {
            this.dbContext = dbContext;
            IncomeSourceList = dbContext.Source_of_income.Local;
            if (income != null)
            {
                CurrentIncome = income;
                ApplyChangesCommand = new RelayCommand(UpdateIncome, CanExe);
            }
            else
            {
                CurrentIncome = new Income();
                CurrentIncome.Date = DateTime.Now;
                ApplyChangesCommand = new RelayCommand(AddIncome, CanExe);
            }
            CurrentIncome.User = dbContext.User.FirstOrDefault();
        }

        private void AddIncome(object parameter)
        {
            DialogResult = true;
            dbContext.Income.Add(CurrentIncome);
            dbContext.SaveChanges();
        }

        private void UpdateIncome(object parameter)
        {
           dbContext.SaveChanges();
        }

        public bool CanExe(object parameter)
        {
            return !(CurrentIncome == null) && CurrentIncome.Sum>0 && CurrentIncome.Source_of_income != null;
        }
    }
}
