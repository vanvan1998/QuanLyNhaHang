using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
using Newtonsoft.Json;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool IsLoginSuccess = false;

        public Employee employee = null; // nhân viên

        public LoginWindow()
        {
            InitializeComponent();
            API.updateCustomer("5cf630ca1c9d440000f94e08", "Tuấn Đẹp Trai", "0123456789");
        }

        private void ExitLoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "")
            {
                tbMessageBox.Text = "Username trống!!!";
                return;
            }
            if (Password.Password == "")
            {
                tbMessageBox.Text = "Password trống!!!";
                return;
            }

            using (MD5 md5Hash = MD5.Create())
            {
                //đăng nhập với password đã mã hóa
                string result = API.login(Username.Text, GetMd5Hash(md5Hash, Password.Password));

                if (result!= "")
                {
                    dynamic stuff = JsonConvert.DeserializeObject(result);
                    IsLoginSuccess = stuff.code;
                    if (IsLoginSuccess)
                    {
                        IsLoginSuccess = true;
                        employee = new Employee()
                        {
                            username = stuff.user.username,
                            password = stuff.user.password,
                            displayName = stuff.user.displayName,
                            role = stuff.user.role
                        };
                        this.Close();
                    }
                }
                else
                {
                    return;
                }
            }
            if (IsLoginSuccess == false)
            {
                tbMessageBox.Text = "Tài khoản hoặc mật khẩu sai!";

            }
        }
    }
}
