using BussinessObjects;
using Services;
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
        private FoodService _foorService;
        public FoodManagementWindow()
        {
            InitializeComponent();
            this._foorService = FoodService.GetInstance();
            LoadFoods();
        }

        private void LoadFoods()
        {
            var foods = _foorService.GetAll();
            dgFood.ItemsSource = foods;
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
            var editWindow = new AddEditFoodWindow(dgFood.SelectedItem as Food);
            if (editWindow.ShowDialog() == true)
            {
                LoadFoods();
            }

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

            var importWindow = new ImportFoodWindow(dgFood.SelectedItem as Food);
            if (importWindow.ShowDialog() == true)
            {
                LoadFoods();
            }
        }
       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }

        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
