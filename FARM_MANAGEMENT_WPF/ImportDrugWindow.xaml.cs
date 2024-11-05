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
    /// Interaction logic for ImportDrugWindow.xaml
    /// </summary>
    public partial class ImportDrugWindow : Window
    {
        private DrugService drugService;
        private Drug drug;

        public ImportDrugWindow(Drug drug)
        {
            InitializeComponent();
            this.drug = drug;
            drugService = DrugService.GetInstance();
            txtDrugInfo.Text = drug.Name + " - " + drug.Type;
            txtCurrentQuantity.Text = drug.Quantity.ToString();
        }

        private void LoadDrugInfo()
        {
            
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn nhập thêm thuốc này không?", "Xác nhận",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int quantity = int.Parse(txtImportQuantity.Text);
                    drugService.ImportDrug(drug, quantity);
                    MessageBox.Show("Nhập thêm thuốc thành công!", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
            }
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

            if (!dpExpiryDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày hết hạn!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                dpExpiryDate.Focus();
                return false;
            }

            if (dpExpiryDate.SelectedDate.Value <= DateTime.Today)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày hiện tại!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                dpExpiryDate.Focus();
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
