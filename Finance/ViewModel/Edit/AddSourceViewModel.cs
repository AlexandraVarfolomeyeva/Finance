using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
   public class AddSourceViewModel : BaseViewModel
    {
        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        FinancesDBContext dbContext;
        public Source_of_income CurrentSource { get; set; }

        public RelayCommand ApplyChangesCommand { get; set; }

        public AddSourceViewModel(FinancesDBContext dbContext)
        {
            this.dbContext = dbContext;
            CurrentSource = new Source_of_income();
                ApplyChangesCommand = new RelayCommand(AddSource, CanExe);
            
        }


        private void AddSource(object parameter)
        {
            DialogResult = true;
            dbContext.Source_of_income.Add(CurrentSource);
            dbContext.SaveChanges();
        }

        public bool CanExe(object parameter)
        {
            return (true);
        }
    }
}
