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
    /// Interaction logic for AddEditFoodWindow.xaml
    /// </summary>
    public partial class AddEditFoodWindow : Window
    {
        public AddEditFoodWindow()
        {
            InitializeComponent();
        }
        

        private void LoadFoodData()
        {
            
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
