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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelManagementApp.Entity;

namespace HotelManagementApp.Setting
{
    /// <summary>
    /// Interaction logic for SettingEmployeeUserControl.xaml
    /// </summary>
    public partial class SettingEmployeeUserControl : UserControl
    {
        List<string> hoTenNhanVien = new List<string>();

        public SettingEmployeeUserControl()
        {
            InitializeComponent();
            LoadEmployeeInfo();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void LoadEmployeeInfo()
        {
            hoTenNhanVien = new List<string>();
            foreach (var nv in DataProvider.Ins.DB.NhanViens.ToList())
            {
                hoTenNhanVien.Add(nv.hoTen);
            }
            EmployeeList.ItemsSource = hoTenNhanVien;
        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex > -1)
            {
                NhanVien nv = DataProvider.Ins.DB.NhanViens.ToList()[((ComboBox)sender).SelectedIndex];
                Name.Text = nv.hoTen;
                Code.Text = nv.maNhanVien;
                Type.Text = nv.loaiNhanVien.ToString();
                BD.Text = nv.ngaySinh.ToShortDateString();
                ID.Text = nv.cmnd;
                Phone.Text = nv.soDienThoai;
            }
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


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Code.Text == "")
            {
                MessageBox.Show("Chưa nhập mã nhân viên!");
                return;
            }

            if (Pass.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu!");
                return;
            }

            foreach (var nv in DataProvider.Ins.DB.NhanViens.ToList())
            {
                if (Code.Text == nv.maNhanVien)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }
            }

            if (Type.Text != "1" && Type.Text != "2")
            {
                MessageBox.Show("Loại nhân viên không đúng!");
                return;
            }

            if (Phone.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại!");
                return;
            }

            if (ID.Text == "")
            {
                MessageBox.Show("Chưa nhập CMND!");
                return;
            }

            if (BD.Text == "")
            {
                MessageBox.Show("Chưa nhập ngày sinh!");
                return;
            }

            using (MD5 md5Hash = MD5.Create())
            {
                NhanVien nhanvien = new NhanVien()
                {
                    maNhanVien = Code.Text,
                    hoTen = Name.Text,
                    matKhau = GetMd5Hash(md5Hash, Pass.Text),
                    cmnd = ID.Text,
                    ngaySinh = new DateTime(1997, 1, 1),
                    loaiNhanVien = int.Parse(Type.Text),
                    soDienThoai = Phone.Text,
                };
                DataProvider.Ins.DB.NhanViens.Add(nhanvien);
                DataProvider.Ins.DB.SaveChanges();

                LoadEmployeeInfo();
                MessageBox.Show("Thêm nhân viên thành công!");
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedIndex > -1)
            {
                if (Code.Text == "")
                {
                    MessageBox.Show("Chưa nhập mã nhân viên!");
                    return;
                }

                if (Pass.Text == "")
                {
                    MessageBox.Show("Chưa nhập mật khẩu!");
                    return;
                }

                if (Type.Text != "1" && Type.Text != "2")
                {
                    MessageBox.Show("Loại nhân viên không đúng!");
                    return;
                }

                if (Phone.Text == "")
                {
                    MessageBox.Show("Chưa nhập số điện thoại!");
                    return;
                }

                if (ID.Text == "")
                {
                    MessageBox.Show("Chưa nhập CMND!");
                    return;
                }

                if (BD.Text == "")
                {
                    MessageBox.Show("Chưa nhập ngày sinh!");
                    return;
                }

                using (MD5 md5Hash = MD5.Create())
                {
                    NhanVien nhanvien = DataProvider.Ins.DB.NhanViens.ToList()[EmployeeList.SelectedIndex];

                    nhanvien.maNhanVien = Code.Text;
                    nhanvien.hoTen = Name.Text;
                    nhanvien.matKhau = GetMd5Hash(md5Hash, Pass.Text);
                    nhanvien.cmnd = ID.Text;
                    nhanvien.ngaySinh = new DateTime(1997, 1, 1);
                    nhanvien.loaiNhanVien = int.Parse(Type.Text);
                    nhanvien.soDienThoai = Phone.Text;

                    DataProvider.Ins.DB.SaveChanges();

                    LoadEmployeeInfo();
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeList.SelectedIndex > -1)
            {
                DataProvider.Ins.DB.NhanViens.Remove(DataProvider.Ins.DB.NhanViens.ToList()[EmployeeList.SelectedIndex]);
                DataProvider.Ins.DB.SaveChanges();

                LoadEmployeeInfo();
                MessageBox.Show("Xóa nhân viên thành công!");

            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên!");
            }
        }
    }
}
