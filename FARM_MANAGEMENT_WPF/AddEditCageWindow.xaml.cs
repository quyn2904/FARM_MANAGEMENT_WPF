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
using static System.Net.Mime.MediaTypeNames;

namespace FARM_MANAGEMENT_WPF
{
    /// <summary>
    /// Interaction logic for AddEditCageWindow.xaml
    /// </summary>
    public partial class AddEditCageWindow : Window
    {
        public AddEditCageWindow()
        {
            InitializeComponent();
        }

       

        private void LoadCageData()
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private bool ValidateInput()
        {
            // Kiểm tra vị trí
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí chuồng!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtLocation.Focus();
                return false;
            }

            // Kiểm tra sức chứa
            if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Sức chứa phải là số nguyên dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtCapacity.Focus();
                return false;
            }

            // Kiểm tra trạng thái
            if (cboStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboStatus.Focus();
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
