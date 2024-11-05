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
    /// Interaction logic for ImportFoodWindow.xaml
    /// </summary>
    public partial class ImportFoodWindow : Window
    {
        private FoodService _foodService;
        private Food food;

        public ImportFoodWindow(Food food)
        {
            InitializeComponent();
            this.food = food;
            _foodService = FoodService.GetInstance();
            txtFoodInfo.Text = food.Name + " - " + food.Type;
            txtCurrentQuantity.Text = food.Quantity.ToString();
        }
        private void LoadFoodInfo()
        {
           
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn nhập thêm thức ăn này không?", "Xác nhận",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int quantity = int.Parse(txtImportQuantity.Text);
                    _foodService.ImportFood(food, quantity);
                    MessageBox.Show("Nhập thêm thức ăn thành công!", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
            }
        }

        private bool ValidateInput()
        {
            if (!int.TryParse(txtImportQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng nhập thêm phải là số dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtImportQuantity.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
