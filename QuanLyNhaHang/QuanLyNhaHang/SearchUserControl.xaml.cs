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
//using QuanLyNhaHang.Entity;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        //public class RoomResult
        //{
        //    public string soPhong { get; set; }
        //    public string thoiGianBatDau { get; set; }
        //    public string hoTen { get; set; }
        //}

        //List<Phong> danhSachPhongTimThayBangSoPhong = new List<Phong>();
        //List<Phong> danhSachPhongTimThayBangTen = new List<Phong>();
        //List<HoaDon> danhSachHoaDonTimThay = new List<HoaDon>();
        //Phong phongHienTai = new Phong();

        public SearchUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 30;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
        //    danhSachPhongTimThayBangSoPhong = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 1 && x.daXoa == 0).ToList();

        //    if (danhSachPhongTimThayBangSoPhong.Count > 0)
        //    {
        //        GridListViewBill.Visibility = Visibility.Hidden;
        //        AreaBillResult.Visibility = Visibility.Hidden;
        //        GridListViewRoom.Visibility = Visibility.Visible;
        //        AreaRoomResult.Visibility = Visibility.Visible;
        //        List<RoomResult> results = new List<RoomResult>();
        //        results.Add(new RoomResult() { soPhong = danhSachPhongTimThayBangSoPhong.Single().soPhong, hoTen = danhSachPhongTimThayBangSoPhong.Single().KhachHang.hoTen, thoiGianBatDau = danhSachPhongTimThayBangSoPhong.Single().thoiGianBatDau.ToString() });
        //        ListViewSearchRoom.ItemsSource = results;
        //        return;
        //    }

        //    danhSachHoaDonTimThay = DataProvider.Ins.DB.HoaDons.Where(x => x.maHoaDon == TbSearch.Text).ToList();
        //    if (danhSachHoaDonTimThay.Count > 0)
        //    {
        //        GridListViewRoom.Visibility = Visibility.Hidden;
        //        AreaRoomResult.Visibility = Visibility.Hidden;
        //        GridListViewBill.Visibility = Visibility.Visible;
        //        AreaBillResult.Visibility = Visibility.Visible;
        //        ListViewSearchBill.ItemsSource = danhSachHoaDonTimThay.ToList();
        //        return;
        //    }


        //    List<KhachHang> customers = DataProvider.Ins.DB.KhachHangs.Where(x => x.hoTen.Contains(TbSearch.Text)).ToList();
        //    List<RoomResult> results1 = new List<RoomResult>();
        //    foreach (var cus in customers)
        //    {
        //        Phong phong = DataProvider.Ins.DB.Phongs.Where(x => x.maKhachHang == cus.maKhachHang).SingleOrDefault();
        //        if (phong != null)
        //        {
        //            danhSachPhongTimThayBangTen.Add(phong);
        //            results1.Add(new RoomResult() { soPhong = phong.soPhong, hoTen = phong.KhachHang.hoTen, thoiGianBatDau = phong.thoiGianBatDau.ToString() });

        //        }
        //    }

        //    if (danhSachPhongTimThayBangTen.Count > 0)
        //    {
        //        GridListViewBill.Visibility = Visibility.Hidden;
        //        AreaBillResult.Visibility = Visibility.Hidden;
        //        GridListViewRoom.Visibility = Visibility.Visible;
        //        AreaRoomResult.Visibility = Visibility.Visible;
        //        ListViewSearchRoom.ItemsSource = results1;
        //        return;
        //    }
        //    GridListViewBill.Visibility = Visibility.Hidden;
        //    AreaBillResult.Visibility = Visibility.Hidden;
        //    GridListViewRoom.Visibility = Visibility.Hidden;
        //    AreaRoomResult.Visibility = Visibility.Hidden;
        //    MessageBox.Show("Không tìm thấy kết quả phù hợp!");
        }

        private void ListViewSearchRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //if (((ListView)sender).SelectedIndex == -1)
            //{
            //    return;
            //}

            //if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            //{
            //    var bc = new BrushConverter();
            //    var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

            //    var dt = cp.ContentTemplate as DataTemplate;
            //    var tb = (TextBlock)dt.FindName("NumberRoom", cp);
            //    var rt = (Rectangle)dt.FindName("BackGround", cp);

            //    if (((ListView)sender).Name == ListViewSearchRoom.Name)
            //    {
            //        List<Phong> phongs;

            //        if (danhSachPhongTimThayBangSoPhong.Count > 0)
            //        {
            //            phongs = danhSachPhongTimThayBangSoPhong;
            //        }
            //        else
            //        {
            //            phongs = danhSachPhongTimThayBangTen;
            //        }
            //        for (int j = 0; j < phongs.Count; j++)
            //        {
            //            ListViewItem lvi1 = ((ListView)sender).ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //            var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

            //            var dt1 = cp1.ContentTemplate as DataTemplate;
            //            var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);

            //            rt1.Fill = Brushes.White;
            //        }

            //        foreach (var room in phongs)
            //        {
            //            if (tb.Text == room.soPhong)
            //            {
            //                phongHienTai = room;

            //                NumberRoom.Text = room.soPhong;
            //                TypeRoom.Text = room.loaiPhong;
            //                CustomerName.Text = room.KhachHang.hoTen;
            //                CustomerID.Text = room.KhachHang.cmnd;
            //                Note.Text = room.ghiChu;
            //                TotalTime.Text = ((DateTime.Now - room.thoiGianBatDau).Value.Days).ToString() + " ngày " + ((DateTime.Now - room.thoiGianBatDau).Value).ToString(@"hh\:mm\:ss");
            //                TotalPay.Text = Math.Round((((DateTime.Now - room.thoiGianBatDau).Value.Hours + ((DateTime.Now - room.thoiGianBatDau).Value.Days) * 24) * phongHienTai.DanhSachBangGia.cacGioSau + phongHienTai.DanhSachBangGia.gioDau), 0).ToString();

            //                if (phongHienTai.loaiPhong.Contains("Tiêu chuẩn"))
            //                {
            //                    NumberRoom.Foreground = (Brush)bc.ConvertFrom("#FF2195F2");
            //                    TypeRoom.Foreground = (Brush)bc.ConvertFrom("#FF2195F2");
            //                }
            //                else
            //                {
            //                    NumberRoom.Foreground = (Brush)bc.ConvertFrom("#FFF3F311");
            //                    TypeRoom.Foreground = (Brush)bc.ConvertFrom("#FFF3F311");
            //                }
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        var hoaDon = danhSachHoaDonTimThay.ToList().Single();

            //        BillNumber.Text = hoaDon.maHoaDon;
            //        TimeCreateBill.Text = hoaDon.thoiGianLap.ToString();
            //        NumberRoomBill.Text = hoaDon.Phong.soPhong;
            //        CustomerNameBill.Text = hoaDon.KhachHang.hoTen;
            //        TotalPayBill.Text = Math.Round(hoaDon.tongTien,0).ToString();
            //        EmployeeID.Text = hoaDon.NhanVien.hoTen;
            //        DiscountCode.Text = hoaDon.maKhuyenMai;

            //        if (hoaDon.Phong.loaiPhong.Contains("Tiêu chuẩn"))
            //        {
            //            BillNumber.Foreground = (Brush)bc.ConvertFrom("#FF2195F2");
            //        }
            //        else
            //        {
            //            BillNumber.Foreground = (Brush)bc.ConvertFrom("#FFF3F311");
            //        }
            //    }
            //    rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");

            //}
        }
    }
}

