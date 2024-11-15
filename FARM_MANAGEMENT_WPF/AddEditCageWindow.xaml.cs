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
using static System.Net.Mime.MediaTypeNames;

namespace FARM_MANAGEMENT_WPF
{
    /// <summary>
    /// Interaction logic for AddEditCageWindow.xaml
    /// </summary>
    public partial class AddEditCageWindow : Window
    {
        private CageService _cageService;
        private CattleByCageService _cattleByCageService;
        private Cage cage;
        public AddEditCageWindow()
        {
            InitializeComponent();
            _cageService = CageService.GetInstance();
            txtTitle.Text = "Add New Cage";
        }

        public AddEditCageWindow(Cage cage)
        {
            InitializeComponent();
            _cageService = CageService.GetInstance();
            _cattleByCageService = CattleByCageService.GetInstance();
            this.cage = cage;
            txtLocation.Text = cage.Location;
            txtTitle.Text = "Update Cage With Id: " + cage.CageId;
            txtCapacity.Text = cage.Capacity.ToString();
            cboStatus.Text = cage.Status;
        }

        private void LoadCageData()
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           if (ValidateInput())
           {
                if (this.cage is null)
                {
                    this.cage = new Cage()
                    {
                        Location = txtLocation.Text,
                        Capacity = int.Parse(txtCapacity.Text),
                        Status = cboStatus.SelectionBoxItem.ToString(),
                    };                    
                    this._cageService.AddNewCage(this.cage);
                    MessageBox.Show("Add New Cage Successfully");
                    this.Close();
                }
                else
                {
                    if (this.cage.Status != cboStatus.SelectionBoxItem.ToString())
                    {
                        if (this._cattleByCageService.IsCageUnempty(cage.CageId))
                        {
                            MessageBox.Show("Please move out all cattle before change status");
                        }
                        else
                        {
                            this.cage.Location = txtLocation.Text;
                            this.cage.Capacity = int.Parse(txtCapacity.Text);
                            this.cage.Status = cboStatus.SelectionBoxItem.ToString();
                            this._cageService.UpdateCage(this.cage);
                            MessageBox.Show("Update Cage Successfully");
                            this.Close();
                        }
                    }     
                }
           }
        }

        private bool ValidateInput()
        {
            // Kiểm tra vị trí
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí chuồng!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtLocation.Focus();
                return false;
            }

            // Kiểm tra sức chứa
            if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Sức chứa phải là số nguyên dương!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                txtCapacity.Focus();
                return false;
            }

            // Kiểm tra trạng thái
            if (cboStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                cboStatus.Focus();
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
