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
    /// Interaction logic for CattleManagementWindow.xaml
    /// </summary>
    public partial class CattleManagementWindow : Window
    {
        private CattleService _cattleService;
        private CageService _cageService;
        public CattleManagementWindow()
        {
            InitializeComponent();
            _cattleService = CattleService.GetInstance();
            _cageService = CageService.GetInstance();
            LoadCages();
            LoadCattles();

        }

        private void LoadCages()
        {
            var cages = _cageService.GetAllCage();
            cboCage.ItemsSource = cages;
            cboCage.DisplayMemberPath = "CageId";
            cboCage.SelectedValuePath = "CageId";
        }

        private void LoadCattles()
        {
            var cattles = _cattleService.GetCattles();
            dgCattle.ItemsSource = cattles;
        }

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var staffWindow = new StaffWindow();
            staffWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditCattleWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadCattles();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {   
            var editWindow = new AddEditCattleWindow(dgCattle.SelectedItem as Cattle);
            editWindow.ShowDialog();
        }

        private void btnFeed_Click(object sender, RoutedEventArgs e)
        {

            var feedWindow = new CattleFeedingWindow();
            feedWindow.ShowDialog();
            
        }

        private void btnMedicine_Click(object sender, RoutedEventArgs e)
        {


            var medicineWindow = new CattleMedicineWindow();
            medicineWindow.ShowDialog();


        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this._cattleService.RemoveCattle(dgCattle.SelectedItem as Cattle);
            LoadCattles();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cboCage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
