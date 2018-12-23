using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ViewModel
{
    class AddCategoryViewModel : BaseViewModel
    {
        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        FinancesDBContext dbContext;
        public Category CurrentCategory { get; set; }

        public RelayCommand ApplyChangesCommand { get; set; }

        public AddCategoryViewModel(FinancesDBContext dbContext)
        {
            this.dbContext = dbContext;
            CurrentCategory = new Category();
            ApplyChangesCommand = new RelayCommand(AddCategory, CanExe);

        }


        private void AddCategory(object parameter)
        {
            DialogResult = true;
            dbContext.Category.Add(CurrentCategory);
            dbContext.SaveChanges();
        }

        public bool CanExe(object parameter)
        {
            return (true);
        }
    }
}
