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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadProducts()
        {
            // TODO: Lấy dữ liệu từ database
   
        
            
        }

        private void CartManager_CartChanged(object sender, EventArgs e)
        {
            UpdateCartCount();
        }

        private void UpdateCartCount()
        {
           // txtCartCount.Text = ;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void ViewCart_Click(object sender, RoutedEventArgs e)
        {
            var cartWindow = new CartWindow();
            cartWindow.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
