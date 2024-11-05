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
    /// Interaction logic for DrugManagementWindow.xaml
    /// </summary>
    public partial class DrugManagementWindow : Window
    {
        private readonly DrugService _drugService;

        public DrugManagementWindow()
        {
            InitializeComponent();
            _drugService = DrugService.GetInstance();
            LoadDrugs();
            cboType.SelectionChanged += cboType_SelectionChanged;
        }

        private void LoadDrugs()
        {
            try
            {
                var drugs = _drugService.GetAll();
                if (drugs == null)
                {
                    MessageBox.Show("Không thể tải danh sách thuốc", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                dgDrug.ItemsSource = drugs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditDrugWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadDrugs();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            var editWindow = new AddEditDrugWindow(dgDrug.SelectedItem as Drug);
            if (editWindow.ShowDialog() == true)
            {
                LoadDrugs();
            }

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

            var importWindow = new ImportDrugWindow(dgDrug.SelectedItem as Drug);
            if (importWindow.ShowDialog() == true)
            {
                LoadDrugs();
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var findDrug = _drugService.GetDrugByName(searchQuery);
                if (findDrug != null)
                {
                    dgDrug.ItemsSource = new List<Drug> { findDrug };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thức ăn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadDrugs();
                }
            }
            else
            {
                LoadDrugs();
            }
        }

        private void cboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboType.SelectedItem == null) return;
            
            string selectedType = ((ComboBoxItem)cboType.SelectedItem).Content.ToString();
            var drugs = _drugService.GetAll();
            
            if (drugs == null)
            {
                MessageBox.Show("Không thể tải danh sách thuốc", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            switch (selectedType)
            {
                case "Vaccine":
                    dgDrug.ItemsSource = drugs.Where(d => d.Type.ToLower() == "vaccine");
                    break;
                case "Kháng sinh":
                    dgDrug.ItemsSource = drugs.Where(d => d.Type.ToLower() == "antibiotic");
                    break;
                case "Vitamin":
                    dgDrug.ItemsSource = drugs.Where(d => d.Type.ToLower() == "vitamin");
                    break;
                default: // "Tất cả loại"
                    dgDrug.ItemsSource = drugs;
                    break;
            }
        }
    }
}
