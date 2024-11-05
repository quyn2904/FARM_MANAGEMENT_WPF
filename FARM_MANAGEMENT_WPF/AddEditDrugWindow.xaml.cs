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
    /// Interaction logic for AddEditDrugWindow.xaml
    /// </summary>
    public partial class AddEditDrugWindow : Window
    {
        private DrugService drugService;
        private Drug drug;
        public AddEditDrugWindow()
        {
            InitializeComponent();
            this.drugService = DrugService.GetInstance();
            lblInitialQuantity.Text = "Số lượng ban đầu(ml)";
            txtUseInstructions.Text = "Hướng dẫn sử dụng";

        }

        public AddEditDrugWindow(Drug drug)
        {
            InitializeComponent();
            this.drugService = DrugService.GetInstance();
            this.drug = drug;
            lblInitialQuantity.Text = "Số lượng ban đầu(ml)";
            txtUseInstructions.Text = "Hướng dẫn sử dụng";
            txtInitialQuantity.IsEnabled = false;
            txtName.Text = drug.Name;
            txtInitialQuantity.Text = drug.Quantity.ToString();
            switch (drug.Type)
            {
                case "vaccine":
                    {
                        cboType.Text = "Vaccine";
                        break;
                    }
                case "antibiotic":
                    {
                        cboType.Text = "Kháng sinh";
                        break;
                    }
                case "vitamin":
                    {
                        cboType.Text = "Vitamin";
                        break;
                    }
                default:
                    {
                        cboType.Text = "";
                        break;
                    }
            }
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
