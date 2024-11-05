using BussinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CageManagementWindow.xaml
    /// </summary>
    public partial class CageManagementWindow : Window
    {
        private CageService _cageService;
        private CattleByCageService _cattleByCageService;
        public CageManagementWindow()
        {
            InitializeComponent();
            _cageService = CageService.GetInstance();
            _cattleByCageService = CattleByCageService.GetInstance();
            LoadCages();
        }

        private void LoadCages()
        {
            var cages = this._cageService.GetAllCage();
            var quantityByCages = this._cattleByCageService.GetCurrentlyOccupiedCagesForEachCage();

            var gridData = from cage in cages
                           join quantityByCage in quantityByCages
                           on cage.CageId equals quantityByCage.CageId into grouped
                           from quantity in grouped.DefaultIfEmpty() // Thực hiện left join
                           select new CageWithQuantity()
                           {
                               Cage = cage,
                               Quantity = quantity?.Quantity ?? 0 // Nếu không có dữ liệu, mặc định là 0
                           };

            dgCages.ItemsSource = gridData.ToList(); // Đảm bảo convert thành List
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditCageWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadCages(); // Reload sau khi thêm
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var cageWithQuantity = dgCages.SelectedItem as CageWithQuantity;
            var editWindow = new AddEditCageWindow(cageWithQuantity.Cage);
            editWindow.ShowDialog();
            LoadCages();
        }
    }
}
