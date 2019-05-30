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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelManagementApp.Entity;

namespace HotelManagementApp.Setting
{
    /// <summary>
    /// Interaction logic for SettingRoomUserControl.xaml
    /// </summary>
    public partial class SettingRoomUserControl : UserControl
    {

        public class RoomResult
        {
            public string soPhong { get; set; }
            public string thoiGianBatDau { get; set; }
            public string hoTen { get; set; }
        }
        Phong phongHienTai = null;

        public SettingRoomUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 80;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            phongHienTai = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.daXoa == 0).SingleOrDefault();

            if (phongHienTai != null)
            {
                if (phongHienTai.tinhTrang == 0)
                {
                    List<Phong> phongs = new List<Phong>();
                    phongs.Add(phongHienTai);
                    ListViewSearchRoom.ItemsSource = phongs;
                }
                else
                {
                    List<RoomResult> rooms = new List<RoomResult>();
                    rooms.Add(new RoomResult() { soPhong = phongHienTai.soPhong, thoiGianBatDau = phongHienTai.thoiGianBatDau.ToString(), hoTen = phongHienTai.KhachHang.hoTen });
                    ListViewSearchRoom.ItemsSource = rooms;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng!");
            }

            NumberRoom.Text = "";
            TypeRoom.Text = "";
            Customername.Text = "";
            CustomerID.Text = "";
            Note.Text = "";


        }

        private void ListViewSearchRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ListViewSearchRoom.SelectedIndex == -1)
            {
                return;
            }

            if (ListViewSearchRoom.ItemContainerGenerator.ContainerFromIndex(ListViewSearchRoom.SelectedIndex) is ListViewItem lvi)
            {
                var bc = new BrushConverter();

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var tb = (TextBlock)dt.FindName("NumberRoom", cp);
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");


                Customername.Text = "";
                CustomerID.Text = "";
                Note.Text = "";

                NumberRoom.Text = phongHienTai.soPhong;
                TypeRoom.Text = phongHienTai.loaiPhong;
                if (phongHienTai.tinhTrang == 1)
                {
                    Customername.Text = phongHienTai.KhachHang.hoTen;
                    CustomerID.Text = phongHienTai.KhachHang.cmnd;
                    Note.Text = phongHienTai.ghiChu;
                }
                if (phongHienTai.loaiPhong.Contains("Tiêu chuẩn"))
                {
                    NumberRoom.Foreground = (Brush)bc.ConvertFrom("#FF2195F2");
                    TypeRoom.Foreground = (Brush)bc.ConvertFrom("#FF2195F2");
                }
                else
                {
                    NumberRoom.Foreground = (Brush)bc.ConvertFrom("#FFF3F311");
                    TypeRoom.Foreground = (Brush)bc.ConvertFrom("#FFF3F311");
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Customername.Text == "" || CustomerID.Text == "")
            {
                MessageBox.Show("Họ tên hoặc CMND trống!");
                return;
            }
            phongHienTai.KhachHang.hoTen = Customername.Text;
            phongHienTai.KhachHang.cmnd = CustomerID.Text;
            phongHienTai.ghiChu = Note.Text;

            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SoPhong.Text == "")
            {
                MessageBox.Show("Chưa nhập số phòng!");
                return;
            }
            bool checkLoaiPhong = false;
            foreach (var room in DataProvider.Ins.DB.DanhSachBangGias)
            {
                if (LoaiPhong.Text == room.loaiPhong)
                {
                    checkLoaiPhong = true;
                    break;
                }
            }
            if (checkLoaiPhong == false)
            {
                MessageBox.Show("Loại phòng không đúng!");
                return;
            }
            bool checkSoPhong = true;
            foreach (var room in DataProvider.Ins.DB.Phongs)
            {
                if (room.soPhong == SoPhong.Text)
                {
                    checkSoPhong = false;
                    break;
                }
            }

            if (checkSoPhong == false)
            {
                MessageBox.Show("Số phòng đã tồn tại!");
            }
            else
            {
                string maPhong = "";
                switch (LoaiPhong.Text)
                {
                    case "Tiêu chuẩn - Đơn":
                        maPhong = "SS" + SoPhong.Text;
                        break;
                    case "Tiêu chuẩn - Đôi":
                        maPhong = "SC" + SoPhong.Text;
                        break;
                    case "Tiêu chuẩn - Nhóm":
                        maPhong = "SG" + SoPhong.Text;
                        break;
                    case "VIP - Đơn":
                        maPhong = "VS" + SoPhong.Text;
                        break;
                    case "VIP - Đôi":
                        maPhong = "VC" + SoPhong.Text;
                        break;
                    case "VIP - Nhóm":
                        maPhong = "VG" + SoPhong.Text;
                        break;
                }
                DataProvider.Ins.DB.Phongs.Add(new Phong() { loaiPhong = LoaiPhong.Text, maKhachHang = null, soPhong = SoPhong.Text, thoiGianBatDau = null, ghiChu = null, tinhTrang = 0, maPhong = maPhong, bangGia = LoaiPhong.Text });
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm phòng thành công!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == SoPhongXoa.Text).Count() == 0)
            {
                MessageBox.Show("Số phòng không đúng!");
                return;
            }
            DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == SoPhongXoa.Text).SingleOrDefault().daXoa = 1;
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Xóa phòng thành công!");
            return;
        }
    }
}
