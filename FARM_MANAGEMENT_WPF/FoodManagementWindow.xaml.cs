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
        private FoodService _foodService;
        public FoodManagementWindow()
        {
            InitializeComponent();
            this._foodService = FoodService.GetInstance();
            LoadFoods();

            //// Đăng ký sự kiện sau khi dữ liệu đã tải
            //cboType.SelectionChanged += cboType_SelectionChanged;
        }


        private void LoadFoods()
        {
            try
            {
                var drugs = _foodService.GetAll();
                if (drugs == null)
                {
                    MessageBox.Show("Không thể tải danh sách thức ăn", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                dgFood.ItemsSource = drugs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            //if (cboType.SelectedItem == null) return;

            //string selectedType = ((ComboBoxItem)cboType.SelectedItem).Content.ToString().ToLower();
            //var foods = _foodService.GetAll();

            //if (foods == null)
            //{
            //    MessageBox.Show("Không thể tải danh sách thức ăn", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //switch (selectedType)
            //{
            //    case "thức ăn con":
            //        dgFood.ItemsSource = foods.Where(d => d.Type.ToLower() == "child");
            //        break;
            //    case "thức ăn tăng trưởng":
            //        dgFood.ItemsSource = foods.Where(d => d.Type.ToLower() == "growth");
            //        break;
            //    case "thức ăn sinh sản":
            //        dgFood.ItemsSource = foods.Where(d => d.Type.ToLower() == "breeding");
            //        break;
            //    default: // "Tất cả loại"
            //        dgFood.ItemsSource = foods;
            //        break;
            //}
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var findFood = _foodService.GetFoodByName(searchQuery);
                if (findFood != null)
                {
                    dgFood.ItemsSource = new List<Food> { findFood };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thức ăn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadFoods();
                }
            }
            else
            {
                LoadFoods();
            }
        }
    }
}
