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
    /// Interaction logic for AddEditCattleWindow.xaml
    /// </summary>
    public partial class AddEditCattleWindow : Window
    {
        public AddEditCattleWindow()
        {
            InitializeComponent();
        }

        private void LoadCages()
        {
           
        }

        private void LoadCattleData()
        {
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private bool ValidateInput()
        {
            // Kiểm tra đã chọn chuồng
            if (cboCage.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chuồng!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboCage.Focus();
                return false;
            }

            // Kiểm tra tuổi
            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtAge.Focus();
                return false;
            }

            // Kiểm tra cân nặng
            if (!double.TryParse(txtWeight.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("Cân nặng phải là số dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtWeight.Focus();
                return false;
            }

            // Kiểm tra tình trạng sức khỏe
            if (cboHealthStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tình trạng sức khỏe!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboHealthStatus.Focus();
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
