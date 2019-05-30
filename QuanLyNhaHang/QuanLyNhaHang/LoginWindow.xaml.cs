using System;
using System.Collections.Generic;
using System.Linq;
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
//using QuanLyNhaHang.Entity;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool IsLoginSuccess = true;
        //public NhanVien nhanVienHienTai = null; // nhân viên

        public LoginWindow()
        {
            InitializeComponent();
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
            using (MD5 md5Hash = MD5.Create())
            {
                //đăng nhập với password đã mã hóa
                //foreach (var nv in DataProvider.Ins.DB.NhanViens.ToList())
                //{
                //    if (Username.Text == nv.maNhanVien && GetMd5Hash(md5Hash, Password.Password) == nv.matKhau)
                //    {
                //        IsLoginSuccess = true;
                //        nhanVienHienTai = nv;
                //        this.Close();
                //        break;
                //    }
                //}
                this.Close();
                IsLoginSuccess = true;
            }


            if (IsLoginSuccess == false)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!");
            }
        }
    }
}
