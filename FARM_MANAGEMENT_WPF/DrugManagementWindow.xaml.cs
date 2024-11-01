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
        public DrugManagementWindow()
        {
            InitializeComponent();
        }

        private void LoadDrugs()
        {
            
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
          
                //var editWindow = new AddEditDrugWindow(drug);
                //if (editWindow.ShowDialog() == true)
                //{
                //    LoadDrugs();
                //}
            
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

                //var importWindow = new ImportDrugWindow(drug);
                //if (importWindow.ShowDialog() == true)
                //{
                //    LoadDrugs();
                //}
            
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

        private void txtSearch_TextChanged(object sender, object e)
        {

        }
    }
}
