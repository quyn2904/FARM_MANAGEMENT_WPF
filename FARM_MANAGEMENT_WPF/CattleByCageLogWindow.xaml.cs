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
    /// Interaction logic for CattleByCageLogWindow.xaml
    /// </summary>
    public partial class CattleByCageLogWindow : Window
    {
        private CattleByCageService _cattleByCageService;
        private CageService _cageService;
        private int _cattleId;
        public CattleByCageLogWindow(int cattleId)
        {
            InitializeComponent();
            _cattleByCageService = CattleByCageService.GetInstance();
            _cageService = CageService.GetInstance();
            _cattleId = cattleId;
            LoadGrid();
        }

        public void LoadGrid()
        {
            var cattleByCages = _cattleByCageService.FindCattleByCage(this._cattleId);
            var cages = _cageService.GetAllCage();
            var dgData = from cattleByCage in cattleByCages
                         join cage in cages
                         on cattleByCage.CageId equals cage.CageId
                         select new
                         {
                             CageId = cage.CageId,
                             Location = cage.Location,
                             StartingTimestamp = cattleByCage.StartingTimestamp,
                             EndingTimestamp = cattleByCage.EndingTimestamp,
                         };
            dgLogs.ItemsSource = dgData;
        }
    }
}
