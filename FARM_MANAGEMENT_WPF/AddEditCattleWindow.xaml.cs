using Services;
using BussinessObjects;
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
    /// Interaction logic for AddEditCattleWindow.xaml
    /// </summary>
    public partial class AddEditCattleWindow : Window
    {
        private CageService _cageService;
        private CattleService _cattleService;
        private CattleByCageService _cattleByCageService;
        private Cattle cattle;
        private Cage cage;
        public AddEditCattleWindow()
        {
            InitializeComponent();
            this._cageService = CageService.GetInstance();
            this._cattleService = CattleService.GetInstance();
            this._cattleByCageService = CattleByCageService.GetInstance();
            LoadCages();
        }

        public AddEditCattleWindow(Cattle catt)
        {
            InitializeComponent();
            this._cageService = CageService.GetInstance();
            this._cattleService = CattleService.GetInstance();
            this._cattleByCageService = CattleByCageService.GetInstance();
            LoadCages();
            this.cattle = catt;

            switch (catt.HealthStatus)
            {
                case "good":
                    cboHealthStatus.SelectedIndex = 0;
                    break;
                case "bad":
                    cboHealthStatus.SelectedIndex = 1;
                    break;
                case "monitor":
                    cboHealthStatus.SelectedIndex = 2;
                    break;
            }
            txtAge.Text = catt.Age.ToString();
            txtWeight.Text = catt.Weight.ToString();
            this.cage = _cageService.GetCageById(_cattleByCageService.GetCurrentCage(this.cattle.CattleId).CageId);
            cboCage.SelectedValue = this.cage.CageId;
        }

        private void LoadCages()
        {
            List<Cage> cages = _cageService.GetAllCage();
            cboCage.ItemsSource = cages;
            cboCage.DisplayMemberPath = "CageId";
            cboCage.SelectedValuePath = "CageId";
        }

        private void LoadCattleData()
        {
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                Cage cage = this._cageService.GetCageById(int.Parse(cboCage.SelectedValue.ToString()));
                string healthstatus = "good";
                if (cboHealthStatus.SelectedItem is ComboBoxItem selectedItem)
                {
                    switch (selectedItem.Content.ToString())
                    {
                        case "Khỏe mạnh":
                            healthstatus = "good";
                            break;
                        case "Bệnh":
                            healthstatus = "bad";
                            break;
                        case "Theo dõi":
                            healthstatus = "monitor";
                            break;
                    }
                }

                if (this.cattle is null)
                {
                    this.cattle = new Cattle()
                    {
                        Age = int.Parse(txtAge.Text),
                        Weight = decimal.Parse(txtWeight.Text),
                        HealthStatus = healthstatus,
                    };
                    this._cattleService.AddNewCattle(cattle);
                    var cattleByCage = new CattleByCage() { CageId = cage.CageId, CattleId = cattle.CattleId, StartingTimestamp = DateTime.Now };
                    this._cattleByCageService.AddNewCattleByCage(cattleByCage);
                    MessageBox.Show("Add new Chicken Successfully");
                    ResetInput();
                }
                else
                {
                    this.cattle.Age = int.Parse(txtAge.Text);
                    this.cattle.Weight = decimal.Parse(txtWeight.Text);
                    this.cattle.HealthStatus = healthstatus;
                    this._cattleService.EditCattle(cattle);
                    if (this.cage.CageId != int.Parse(cboCage.SelectedValue.ToString()))
                    {
                        var currentCattleByCage = this._cattleByCageService.GetDefaultCage(this.cattle.CattleId);
                        currentCattleByCage.EndingTimestamp = DateTime.Now;
                        this._cattleByCageService.UpdateCattleByCage(currentCattleByCage);
                        var cattleByCage = new CattleByCage() { CageId = cage.CageId, CattleId = cattle.CattleId, StartingTimestamp = DateTime.Now };
                        this._cattleByCageService.AddNewCattleByCage(cattleByCage);
                    }
                    MessageBox.Show("Edit Chicken Successfully");

                }
            }
        }

        private void ResetInput()
        {
            cboCage.SelectedItem = null;
            txtAge.Text = string.Empty;
            txtWeight.Text = string.Empty;
            cboHealthStatus.SelectedItem = null;
        }

        private bool ValidateInput()
        {
            // Kiểm tra đã chọn chuồng
            if (cboCage.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chuồng!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboCage.Focus();
                return false;
            }

            // Kiểm tra tuổi
            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Tuổi phải là số nguyên dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtAge.Focus();
                return false;
            }

            // Kiểm tra cân nặng
            if (!decimal.TryParse(txtWeight.Text, out decimal weight) || weight <= 0)
            {
                MessageBox.Show("Cân nặng phải là số dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtWeight.Focus();
                return false;
            }

            // Kiểm tra tình trạng sức khỏe
            if (cboHealthStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tình trạng sức khỏe!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboHealthStatus.Focus();
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
