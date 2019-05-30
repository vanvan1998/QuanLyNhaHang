using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace QuanLyNhaHang.UsingTables
{
    /// <summary>
    /// Interaction logic for UserControlVIPUsedTable.xaml
    /// </summary>
    public partial class UsingVIPTablesUserControl : UserControl
    {
        //ObservableCollection<Phong> UsingVIPSingleTables = new ObservableCollection<Phong>();
        //ObservableCollection<Phong> UsingVIPCoupleTables = new ObservableCollection<Phong>();
        //ObservableCollection<Phong> UsingVIPGroupTables = new ObservableCollection<Phong>();

        //ListView lvHienTai = null;
        //ListViewItem lviHienTai = null;
        //Phong phongHienTai = null;

        public UsingVIPTablesUserControl()
        {
            InitializeComponent();

            //foreach (var room in DataProvider.Ins.DB.Phongs.ToList())
            //{
            //    if (room.tinhTrang == 1 && room.daXoa == 0)
            //    {
            //        if (room.loaiPhong == "VIP - Đơn")
            //        {
            //            UsingVIPSingleTables.Add(room);
            //        }
            //        else if (room.loaiPhong == "VIP - Đôi")
            //        {
            //            UsingVIPCoupleTables.Add(room);
            //        }
            //        else if (room.loaiPhong == "VIP - Nhóm")
            //        {
            //            UsingVIPGroupTables.Add(room);
            //        }
            //    }
            //}

            //ListViewUsingVIPSingleTable.ItemsSource = UsingVIPSingleTables;
            //ListViewUsingVIPCoupleTable.ItemsSource = UsingVIPCoupleTables;
            //ListViewUsingVIPGroupTable.ItemsSource = UsingVIPGroupTables;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewUsingVIPTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //if (((ListView)sender).SelectedIndex == -1)
            //{
            //    return;
            //}

            //if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            //{
            //    lvHienTai = (ListView)sender;
            //    lviHienTai = lvi;

            //    var bc = new BrushConverter();

            //    for (int j = 0; j < UsingVIPSingleTables.Count; j++)
            //    {
            //        ListViewItem lvi1 = ListViewUsingVIPSingleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

            //        var dt1 = cp1.ContentTemplate as DataTemplate;
            //        var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
            //        var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);

            //        rt1.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < UsingVIPCoupleTables.Count; j++)
            //    {
            //        ListViewItem lvi2 = ListViewUsingVIPCoupleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

            //        var dt2 = cp2.ContentTemplate as DataTemplate;
            //        var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
            //        var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);

            //        rt2.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < UsingVIPGroupTables.Count; j++)
            //    {
            //        ListViewItem lvi3 = ListViewUsingVIPGroupTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp3 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi3);

            //        var dt3 = cp3.ContentTemplate as DataTemplate;
            //        var rt3 = (Rectangle)dt3.FindName("BackGround", cp3);
            //        var tb3 = (TextBlock)dt3.FindName("NumberTable", cp3);

            //        rt3.Fill = Brushes.White;
            //    }

            //    var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

            //    var dt = cp.ContentTemplate as DataTemplate;
            //    var rt = (Rectangle)dt.FindName("BackGround", cp);
            //    var tb = (TextBlock)dt.FindName("NumberTable", cp);

            //    foreach (var room in DataProvider.Ins.DB.Phongs.ToList())
            //    {
            //        if (tb.Text == room.soPhong)
            //        {
            //            phongHienTai = room;

            //            NumberTable.Text = room.soPhong;
            //            TypeTable.Text = room.loaiPhong;
            //            Customername.Text = room.KhachHang.hoTen;
            //            CustomerID.Text = room.KhachHang.cmnd;
            //            NoteTextBlock.Text = room.ghiChu;
            //            Time.Text = ((DateTime.Now - room.thoiGianBatDau).Value.Days).ToString() + " ngày " + ((DateTime.Now - room.thoiGianBatDau).Value).ToString(@"hh\:mm\:ss");
            //            Total.Text = Math.Round((((DateTime.Now - room.thoiGianBatDau).Value.Hours + ((DateTime.Now - room.thoiGianBatDau).Value.Days) * 24) * phongHienTai.DanhSachBangGia.cacGioSau + phongHienTai.DanhSachBangGia.gioDau), 0).ToString();

            //            break;
            //        }
            //    }

            //    rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            //}
        }

        private void BtnThanhToan(object sender, RoutedEventArgs e)
        {
            //if (NumberTable.Text == "")
            //{
            //    MessageBox.Show("Chưa chọn phòng!");
            //    return;
            //}

            //var re1 = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == NumberTable.Text).SingleOrDefault();

            //string maHD = "HD1";
            //string maKM = null;

            //if (DataProvider.Ins.DB.HoaDons.Count() > 0)
            //{
            //    maHD = "HD" + (DataProvider.Ins.DB.HoaDons.Max(x=>x.id) + 1).ToString();
            //}

            //if (DiscountCodeTextBox.Text != "")
            //{
            //    var DSMKM = DataProvider.Ins.DB.DanhSachMaKhuyenMais.Where(x => x.maKhuyenMai == DiscountCodeTextBox.Text).SingleOrDefault();

            //    if (DSMKM == null)
            //    {
            //        MessageBox.Show("Mã giảm giá không đúng!");
            //        return;
            //    }
            //    else
            //    {
            //        maKM = DSMKM.maKhuyenMai;
            //    }
            //}

            //HoaDon hoaDon = new HoaDon
            //{
            //    thoiGianLap = DateTime.Now,
            //    maHoaDon = maHD,
            //    maKhachHang = phongHienTai.maKhachHang,
            //    maNhanVienLap = "nhanvien", //xu li sau
            //    maPhong = phongHienTai.maPhong,
            //    tongTien = Math.Round(decimal.Parse(Total.Text), 0),
            //    maKhuyenMai = maKM,
            //};

            //DataProvider.Ins.DB.HoaDons.Add(hoaDon);
            //DataProvider.Ins.DB.SaveChanges();

            //foreach (var room in UsingVIPSingleTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingVIPSingleTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewUsingVIPSingleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingVIPSingleTable.ItemsSource = UsingVIPSingleTables;

            //foreach (var room in UsingVIPCoupleTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingVIPCoupleTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewUsingVIPCoupleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingVIPCoupleTable.ItemsSource = UsingVIPCoupleTables;

            //foreach (var room in UsingVIPGroupTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingVIPGroupTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewUsingVIPGroupTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingVIPGroupTable.ItemsSource = UsingVIPGroupTables;

            //phongHienTai.tinhTrang = 0;
            //phongHienTai.thoiGianBatDau = null;
            //phongHienTai.maKhachHang = null;
            //phongHienTai.ghiChu = null;

            //DataProvider.Ins.DB.SaveChanges();
            //MessageBox.Show("Đã thanh toán thành công!");

            //NumberTable.Text = "";
            //TypeTable.Text = "";
            //Customername.Text = "";
            //CustomerID.Text = "";
            //Time.Text = "";
            //Total.Text = "";
            //NoteTextBlock.Text = "";
            //DiscountCodeTextBox.Text = "";
        }

        private void DiscountCodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if (DiscountCodeTextBox.Text != "")
            //{
            //    var re = DataProvider.Ins.DB.DanhSachMaKhuyenMais.Where(x => x.maKhuyenMai == DiscountCodeTextBox.Text).SingleOrDefault();

            //    if (re == null)
            //    {
            //        Total.Text = Math.Round((((DateTime.Now - phongHienTai.thoiGianBatDau).Value.Hours + ((DateTime.Now - phongHienTai.thoiGianBatDau).Value.Days) * 24) * phongHienTai.DanhSachBangGia.cacGioSau + phongHienTai.DanhSachBangGia.gioDau), 0).ToString();
            //    }
            //    else
            //    {
            //        Total.Text = (decimal.Parse(Total.Text) * (100 - re.phanTramGiam) / 100).ToString();
            //    }
            //}
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //var room = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 1 && x.daXoa == 0).SingleOrDefault();

            //if (room != null)
            //{
            //    NumberTable.Text = room.soPhong;
            //    TypeTable.Text = room.loaiPhong;
            //    Customername.Text = room.KhachHang.hoTen;
            //    CustomerID.Text = room.KhachHang.cmnd;
            //    NoteTextBlock.Text = room.ghiChu;
            //    Time.Text = ((DateTime.Now - room.thoiGianBatDau).Value.Days).ToString() + " ngày " + ((DateTime.Now - room.thoiGianBatDau).Value).ToString(@"hh\:mm\:ss");
            //    Total.Text = Math.Round((((DateTime.Now - room.thoiGianBatDau).Value.Hours + ((DateTime.Now - room.thoiGianBatDau).Value.Days) * 24) * room.DanhSachBangGia.cacGioSau + room.DanhSachBangGia.gioDau), 0).ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Số phòng không đúng!");
            //}
        }
    }
}
