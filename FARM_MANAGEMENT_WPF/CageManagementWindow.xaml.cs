using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CageManagementWindow.xaml
    /// </summary>
    public partial class CageManagementWindow : Window
    {

        public CageManagementWindow()
        {
            InitializeComponent();
        }

        private void LoadCages()
        {
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditCageWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadCages(); // Reload sau khi thêm
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //var cage = (sender as Button).DataContext as Cage;
            //if (cage != null)
            //{
            //    var editWindow = new AddEditCageWindow(cage);
            //    if (editWindow.ShowDialog() == true)
            //    {
            //        LoadCages(); // Reload sau khi sửa
            //    }
            //}
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }




    }
}
