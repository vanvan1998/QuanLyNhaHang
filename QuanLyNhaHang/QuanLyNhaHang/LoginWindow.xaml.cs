using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
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
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            XDocument objDoc = XDocument.Load(path + "/Config/Rememberme.xml");

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

            if (RememberMe.IsChecked == true)
            {
                objDoc.Root.Elements().ElementAt(0).Value = "True";
                objDoc.Root.Elements().ElementAt(1).Value = Username.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    objDoc.Root.Elements().ElementAt(2).Value = GetMd5Hash(md5Hash, Password.Password);
                }
                objDoc.Save(path + "/Config/Rememberme.xml");
            }
            else
            {
                objDoc.Root.Elements().ElementAt(0).Value = "False";
            }

            DoLogin(Username.Text, Password.Password);
        }

        private void checkRememberMe()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            XDocument objDoc = XDocument.Load(path + "/Config/Rememberme.xml");

            if (objDoc.Root.Elements().ElementAt(0).Value == "True")
            {
                string username = objDoc.Root.Elements().ElementAt(1).Value;
                string password = objDoc.Root.Elements().ElementAt(2).Value;

                DoLogin(username, password, false);
            }
        }

        private void DoLogin(string username, string password, bool hash = true)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string result;
                if (hash == true)
                {
                    //đăng nhập với password chưa mã hóa
                    result = API.login(username, GetMd5Hash(md5Hash, password));
                }
                else
                {
                    //đăng nhập với password đã mã hóa
                    result = API.login(username, password);
                }

                if (result != "")
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkRememberMe();
        }
    }
}
