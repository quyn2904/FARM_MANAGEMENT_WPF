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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private StaffService _staffService;
        public LoginWindow()
        {
            InitializeComponent();
            this._staffService = StaffService.GetInstance();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý logic đăng nhập ở đây
            string email = txtUsername.Text;
            string password = txtPassword.Password;

            // TODO: Thêm logic kiểm tra đăng nhập
            var staff = this._staffService.Login(email, password);
            if (staff is not null)
            {
                if (staff.Position is not null && staff.Position.Equals("Admin"))
                {
                    MessageBox.Show("Admin Đăng nhập thành công");
                    // TODO: show admin window
                } 
                else
                {
                    MessageBox.Show("Staff Đăng nhập thành công");
                    StaffWindow staffWindow = new StaffWindow();
                    staffWindow.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
