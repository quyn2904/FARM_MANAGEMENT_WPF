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
    /// Interaction logic for FoodManagementWindow.xaml
    /// </summary>
    public partial class FoodManagementWindow : Window
    {
        public FoodManagementWindow()
        {
            InitializeComponent();
        }

        private void LoadFoods()
        {
          
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditFoodWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadFoods();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
                //var editWindow = new AddEditFoodWindow(food);
                //if (editWindow.ShowDialog() == true)
                //{
                //    LoadFoods();
                //}
            
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
           
                //var importWindow = new ImportFoodWindow(food);
                //if (importWindow.ShowDialog() == true)
                //{
                //    LoadFoods();
                //}
           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }
    }
}
