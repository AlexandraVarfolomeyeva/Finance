using Finance.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Finance
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public MainWindowViewModel MainVM { set; get; }

        public Window2(int Id, FinancesDBContext db)
        {
            MainVM = new MainWindowViewModel(db, Id);
            DataContext = MainVM;
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
