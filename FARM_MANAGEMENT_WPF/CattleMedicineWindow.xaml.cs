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
    /// Interaction logic for CattleMedicineWindow.xaml
    /// </summary>
    public partial class CattleMedicineWindow : Window
    {
        public CattleMedicineWindow()
        {
            InitializeComponent();
        }

        private void LoadInitialData()
        {
            
        }

        private void LoadDrugs()
        {
            
        }

        private void LoadMedicineHistory()
        {
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private bool ValidateInput()
        {
            if (cboDrug.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboDrug.Focus();
                return false;
            }

            if (!double.TryParse(txtDosage.Text, out double dosage) || dosage <= 0)
            {
                MessageBox.Show("Liều lượng phải là số dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtDosage.Focus();
                return false;
            }

            if (!dpInjectionDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày tiêm!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                dpInjectionDate.Focus();
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           
            
        }
    }
}
