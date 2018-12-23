using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Finance.ViewModel
{
    public class EditPurchaseViewModel : BaseViewModel
    {
        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        FinancesDBContext dbContext;
        public Purchase CurrentPurchase { get; set; }

        public RelayCommand ApplyChangesCommand { get; set; }

        public EditPurchaseViewModel(FinancesDBContext dbContext, Purchase purchase, int Id)
        {
            this.dbContext = dbContext;
            if (purchase != null)
            {
                CurrentPurchase = purchase;
                ApplyChangesCommand = new RelayCommand(UpdatePurchase, CanExe);
            }
            else
            {
                CurrentPurchase = new Purchase();

                ApplyChangesCommand = new RelayCommand(AddPurchase, CanExe);
            }
            //CurrentPurchase.User = dbContext.User.FirstOrDefault();
            CurrentPurchase.UserId = Id;
        }

        private void AddPurchase(object parameter)
        {
            try
            {
                DialogResult = true;
                if (CurrentPurchase.Name == null) CurrentPurchase.Name = "Неизвестно";
                dbContext.Purchase.Add(CurrentPurchase);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdatePurchase(object parameter)
        {
            dbContext.SaveChanges();
        }

        public bool CanExe(object parameter)
        {
            return !(CurrentPurchase == null) && CurrentPurchase.Name != "";
        }
    }
}
