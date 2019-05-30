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
    /// Interaction logic for UserControlStandardUsedTable.xaml
    /// </summary>

    public partial class UsingStandardTablesUserControl : UserControl
    {
        //ObservableCollection<Phong> UsingStandardSingleTables = new ObservableCollection<Phong>();
        //ObservableCollection<Phong> UsingStandardCoupleTables = new ObservableCollection<Phong>();
        //ObservableCollection<Phong> UsingStandardGroupTables = new ObservableCollection<Phong>();

        //ListView lvHienTai = null;
        //ListViewItem lviHienTai = null;
        //Phong phongHienTai = null;

        public UsingStandardTablesUserControl()
        {
            InitializeComponent();

            //foreach (var table in DataProvider.Ins.DB.Phongs.ToList())
            //{
            //    if (table.tinhTrang == 1 && table.daXoa == 0)
            //    {
            //        if (table.loaiPhong == "Tiêu chuẩn - Đơn")
            //        {
            //            UsingStandardSingleTables.Add(table);
            //        }
            //        else if (table.loaiPhong == "Tiêu chuẩn - Đôi")
            //        {
            //            UsingStandardCoupleTables.Add(table);
            //        }
            //        else if (table.loaiPhong == "Tiêu chuẩn - Nhóm")
            //        {
            //            UsingStandardGroupTables.Add(table);
            //        }
            //    }
            //}

            //ListViewUsingStandardSingleTable.ItemsSource = UsingStandardSingleTables;
            //ListViewUsingStandardCoupleTable.ItemsSource = UsingStandardCoupleTables;
            //ListViewUsingStandardGroupTable.ItemsSource = UsingStandardGroupTables;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewUsingStandardTable_MouseUp(object sender, MouseButtonEventArgs e)
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

            //    for (int j = 0; j < UsingStandardSingleTables.Count; j++)
            //    {
            //        ListViewItem lvi1 = ListViewUsingStandardSingleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

            //        var dt1 = cp1.ContentTemplate as DataTemplate;
            //        var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
            //        var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);

            //        rt1.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < UsingStandardCoupleTables.Count; j++)
            //    {
            //        ListViewItem lvi2 = ListViewUsingStandardCoupleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

            //        var dt2 = cp2.ContentTemplate as DataTemplate;
            //        var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
            //        var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);

            //        rt2.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < UsingStandardGroupTables.Count; j++)
            //    {
            //        ListViewItem lvi3 = ListViewUsingStandardGroupTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
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

            //    foreach (var table in DataProvider.Ins.DB.Phongs.ToList())
            //    {
            //        if (tb.Text == table.soPhong)
            //        {
            //            phongHienTai = table;
                        
            //            NumberTable.Text = table.soPhong;
            //            TypeTable.Text = table.loaiPhong;
            //            Customername.Text = table.KhachHang.hoTen;
            //            CustomerID.Text = table.KhachHang.cmnd;
            //            NoteTextBlock.Text = table.ghiChu;
            //            Time.Text = ((DateTime.Now - table.thoiGianBatDau).Value.Days).ToString() + " ngày " + ((DateTime.Now - table.thoiGianBatDau).Value).ToString(@"hh\:mm\:ss");
            //            Total.Text = Math.Round((((DateTime.Now - table.thoiGianBatDau).Value.Hours + ((DateTime.Now - table.thoiGianBatDau).Value.Days) * 24) * phongHienTai.DanhSachBangGia.cacGioSau + phongHienTai.DanhSachBangGia.gioDau), 0).ToString();

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

            //foreach (var table in UsingStandardSingleTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingStandardSingleTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewUsingStandardSingleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingStandardSingleTable.ItemsSource = UsingStandardSingleTables;

            //foreach (var table in UsingStandardCoupleTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingStandardCoupleTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewUsingStandardCoupleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingStandardCoupleTable.ItemsSource = UsingStandardCoupleTables;

            //foreach (var table in UsingStandardGroupTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingStandardGroupTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewUsingStandardGroupTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingStandardGroupTable.ItemsSource = UsingStandardGroupTables;

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
            //var table = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 1 && x.daXoa == 0).SingleOrDefault();

            //if (table != null)
            //{
            //    NumberTable.Text = table.soPhong;
            //    TypeTable.Text = table.loaiPhong;
            //    Customername.Text = table.KhachHang.hoTen;
            //    CustomerID.Text = table.KhachHang.cmnd;
            //    NoteTextBlock.Text = table.ghiChu;
            //    Time.Text = ((DateTime.Now - table.thoiGianBatDau).Value.Days).ToString() + " ngày " + ((DateTime.Now - table.thoiGianBatDau).Value).ToString(@"hh\:mm\:ss");
            //    Total.Text = Math.Round((((DateTime.Now - table.thoiGianBatDau).Value.Hours + ((DateTime.Now - table.thoiGianBatDau).Value.Days) * 24) * table.DanhSachBangGia.cacGioSau + table.DanhSachBangGia.gioDau), 0).ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Số phòng không đúng!");
            //}
        }
    }
}
