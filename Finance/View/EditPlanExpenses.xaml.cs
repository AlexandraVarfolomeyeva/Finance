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

namespace Finance.View
{
    /// <summary>
    /// Логика взаимодействия для EditPlanExpenses.xaml
    /// </summary>
    public partial class EditPlanExpenses : Window
    {
        public EditPlanExpenses()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
