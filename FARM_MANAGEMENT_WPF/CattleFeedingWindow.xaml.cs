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
    /// Interaction logic for CattleFeedingWindow.xaml
    /// </summary>
    public partial class CattleFeedingWindow : Window
    {
        private Cattle cattle;
        private Cage cage;
        private CattleByCageService _cattleByCageService;
        private CattleFoodScheduleService _cattleFoodScheduleService;
        private FoodService _foodService;
        private CageService _cageService;
        public CattleFeedingWindow(Cattle cattle)
        {
            InitializeComponent();
            _cattleByCageService = CattleByCageService.GetInstance();
            _cattleFoodScheduleService = CattleFoodScheduleService.GetInstance();
            _cageService = CageService.GetInstance();
            _foodService = FoodService.GetInstance();
            this.cattle = cattle;
            var cageId = _cattleByCageService.GetDefaultCage(cattle.CattleId).CageId;
            this.cage = _cageService.GetCageById(cageId);
            txtCattleInfo.Text = $"Thông tin gà: {cattle.CattleId} - Chuồng: {cageId}";
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            LoadFoods();
            LoadFeedingHistory();
        }

        private void LoadFoods()
        {
            var foods = _foodService.GetAll();
            cboFood.ItemsSource = foods;
            cboFood.DisplayMemberPath = "Name";
            cboFood.SelectedValuePath = "FoodId";
        }

        private void LoadFeedingHistory()
        {
            var feedingHistories = _cattleFoodScheduleService.GetFeedingHistory(cattle.CattleId);
            var feedingHistoriesWithFoodName = from FeedingHistory in feedingHistories
                                               select new CattleFoodSchedule()
                                               {
                                                   CattleId = FeedingHistory.CattleId,
                                                   FeedingTime = FeedingHistory.FeedingTime,
                                                   FoodId = FeedingHistory.FoodId,
                                                   Quantity = FeedingHistory.Quantity,
                                                   ScheduleId = FeedingHistory.ScheduleId,
                                                   Food = _foodService.GetFoodById(FeedingHistory.FoodId),
                                                   Cattle = this.cattle,

                                               };
            dgFeedingHistory.ItemsSource = feedingHistoriesWithFoodName.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var CattleFoodSchedule = new CattleFoodSchedule
                {
                    CattleId = cattle.CattleId,
                    FoodId = (int)cboFood.SelectedValue,
                    Quantity = int.Parse(txtAmount.Text),
                    FeedingTime = dpFeedingDate.SelectedDate.Value.ToString(),
                };
                this._cattleFoodScheduleService.AddFeedingHistory(CattleFoodSchedule);
                LoadFeedingHistory();
                MessageBox.Show("Thêm lịch sử cho ăn thành công!", "Thông báo",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                ResetInput();
            }
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

        private void ResetInput()
        {
            dpFeedingDate.SelectedDate = null;
            txtAmount.Text = string.Empty;
            cboFood.SelectedIndex = -1;
        }
    }
}
