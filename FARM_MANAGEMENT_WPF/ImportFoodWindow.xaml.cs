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
        public ImportFoodWindow()
        {
            InitializeComponent();
        }
        private void LoadFoodInfo()
        {
           
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private bool ValidateInput()
        {
            if (!double.TryParse(txtImportQuantity.Text, out double quantity) || quantity <= 0)
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
