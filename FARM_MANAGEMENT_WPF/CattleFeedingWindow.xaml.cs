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
    /// Interaction logic for CattleFeedingWindow.xaml
    /// </summary>
    public partial class CattleFeedingWindow : Window
    {
        public CattleFeedingWindow()
        {
            InitializeComponent();
        }

        private void LoadInitialData()
        {
            
        }

        private void LoadFoods()
        {
            
        }

        private void LoadFeedingHistory()
        {
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private bool ValidateInput()
        {
            if (cboFood.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thức ăn!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboFood.Focus();
                return false;
            }

            if (!int.TryParse(txtAmount.Text, out int amount) || amount <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtAmount.Focus();
                return false;
            }

            if (!dpFeedingDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày cho ăn!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                dpFeedingDate.Focus();
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
