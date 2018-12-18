using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Finance;

namespace Finance.View
{
    /// <summary>
    /// Логика взаимодействия для EditIncome.xaml
    /// </summary>
    public partial class EditIncome : Window
    {
        public EditIncome()
        {
            InitializeComponent();  
        }

        FinancesDBContext db = new FinancesDBContext();
        Source_of_income inc;
        private void CloseWind(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string _selectedItem; 

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                //OnPropertyChanged("SelectedItem");
            }
        } 
        public string NewItem
        {
            set
            {
                if (SelectedItem != null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(value))
                {
                    inc.Name = value; 
                   db.Source_of_income.Add(inc);
                    db.SaveChanges();
                }
            }
        }


    }
}
