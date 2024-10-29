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
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            LoadCartItems();
            UpdateTotalAmount();
        }
        private void LoadCartItems()
        {
           
        }

        private void UpdateTotalAmount()
        {
            // txtTotalAmount.Text = 
        }

        private void BackToProducts_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private async void Checkout_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async Task SaveOrder()
        {
            // TODO: Implement saving order to database
            // 1. Create new Order
            // 2. Create OrderItems
            // 3. Update product quantities
            await Task.Delay(1000); // Simulating database operation
        }
    }
}
