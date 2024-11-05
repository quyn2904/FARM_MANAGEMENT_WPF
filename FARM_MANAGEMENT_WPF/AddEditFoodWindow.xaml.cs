using BussinessObjects;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    /// Interaction logic for AddEditFoodWindow.xaml
    /// </summary>
    public partial class AddEditFoodWindow : Window
    {
        private FoodService _foodService;
        private Food food;
        public AddEditFoodWindow()
        {
            InitializeComponent();
            this._foodService = FoodService.GetInstance();
            lblInitialQuantity.Text = "Số lượng ban đầu (kg)";
        }

        private void LoadFoodData()
        {    
        }

        public AddEditFoodWindow(Food food)
        {
            InitializeComponent();
            this._foodService = FoodService.GetInstance();
            lblInitialQuantity.Text = "Số lượng tồn kho (kg)";
            txtInitialQuantity.IsEnabled = false;
            this.food = food;
            txtName.Text = food.Name;
            txtInitialQuantity.Text = food.Quantity.ToString();
            switch (food.Type) 
            {
                case "child":
                    {
                        cboType.Text = "Thức ăn con";
                        break;
                    }
                case "growth":
                    {
                        cboType.Text = "Thức ăn tăng trưởng";
                        break;
                    }
                case "breeding":
                    {
                        cboType.Text = "Thức ăn sinh sản";
                        break;
                    }
                default:
                    {
                        cboType.Text = "";
                        break;
                    }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.food is null)
            {
                string type = "";
                if (cboType.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại thức ăn!", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                switch (cboType.Text)
                {
                    case "Thức ăn con":
                        {
                            type = "child";
                            break;
                        }
                    case "Thức ăn tăng trưởng":
                        {
                            type = "growth";
                            break;
                        }
                    case "Thức ăn sinh sản":
                        {
                            type = "breeding";
                            break;
                        }
                }
                // add
                this.food = new Food()
                {
                    Name = txtName.Text,
                    Quantity = int.Parse(txtInitialQuantity.Text),
                    Type = type
                };
                this._foodService.AddNewFood(this.food);
                MessageBox.Show("Thêm thức ăn mới thành công!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // edit
                switch (cboType.Text)
                {
                    case "Thức ăn con":
                        {
                            this.food.Type = "child";
                            break;
                        }
                    case "Thức ăn tăng trưởng":
                        {
                            this.food.Type = "growth";
                            break;
                        }
                    case "Thức ăn sinh sản":
                        {
                            this.food.Type = "breeding";
                            break;
                        }
                }
                // add
                this.food.Name = txtName.Text;
                this.food.Quantity = int.Parse(txtInitialQuantity.Text);
                this._foodService.UpdateFood(this.food);
                MessageBox.Show("Cập nhật thông tin thức ăn thành công!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            DialogResult = true;
            Close();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
