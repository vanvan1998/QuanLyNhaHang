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
        const string SERVER = "http://localhost:3000/api";
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

        public string GET(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public string POST(string uri, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Write("\n");
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private string loginRequest(string username, string password)
        {
            string json = "{\"username\": \"" + username + "\", \"password\": \"" + password + "\"}";
            string url = SERVER + "/login";

            try
            {
                return POST(url, json);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server");
                return "";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO kiểm tra username và password có trống không? 
            if ((Username.Text == "") && (Password.Password == ""))
            {
                tbMessageBox.Text = "username và password trống!!!";
            }
            else if (Username.Text == "")
            {
                tbMessageBox.Text = "username trống!!!";
            }
            else if (Password.Password == "")
            {
                tbMessageBox.Text = "password trống!!!";
            }
            else
            { 
                using (MD5 md5Hash = MD5.Create())
            {
                //đăng nhập với password đã mã hóa
                string result = loginRequest(Username.Text, GetMd5Hash(md5Hash, Password.Password));
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
                if (IsLoginSuccess == false)
            {
                tbMessageBox.Text="Tài khoản hoặc mật khẩu sai!";
            }
            }
        }
    }
}
