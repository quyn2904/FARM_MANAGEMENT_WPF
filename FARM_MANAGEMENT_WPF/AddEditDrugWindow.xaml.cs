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
    /// Interaction logic for AddEditDrugWindow.xaml
    /// </summary>
    public partial class AddEditDrugWindow : Window
    {
        public AddEditDrugWindow()
        {
            InitializeComponent();
        }



        private void LoadDrugData()
        {
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return false;
            }

            if (cboType.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại thuốc!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboType.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtUseInstructions.Text))
            {
                MessageBox.Show("Vui lòng nhập hướng dẫn sử dụng!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUseInstructions.Focus();
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
