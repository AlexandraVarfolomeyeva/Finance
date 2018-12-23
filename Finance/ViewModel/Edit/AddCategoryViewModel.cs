using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                DialogResult = true;
                dbContext.Category.Add(CurrentCategory);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanExe(object parameter)
        {
            return (true);
        }
    }
}
