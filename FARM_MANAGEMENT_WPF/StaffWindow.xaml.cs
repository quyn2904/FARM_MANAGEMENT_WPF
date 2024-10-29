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

namespace FARM_MANAGEMENT_WPF
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                                       MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void btnCage_Click(object sender, RoutedEventArgs e)
        {
            var cageWindow = new CageManagementWindow();
            cageWindow.Show();
        }

        private void btnCattle_Click(object sender, RoutedEventArgs e)
        {
            var cattleWindow = new CattleManagementWindow();
            cattleWindow.Show();
        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            var foodWindow = new FoodManagementWindow();
            foodWindow.Show();
        }

        private void btnDrug_Click(object sender, RoutedEventArgs e)
        {
            var drugWindow = new DrugManagementWindow();
            drugWindow.Show();
        }
    }
}
