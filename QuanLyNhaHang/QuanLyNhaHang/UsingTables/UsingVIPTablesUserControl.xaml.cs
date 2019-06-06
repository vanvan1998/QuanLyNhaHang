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
using Newtonsoft.Json;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.UsingTables
{
    /// <summary>
    /// Interaction logic for UserControlVIPUsedTable.xaml
    /// </summary>
    public partial class UsingVIPTablesUserControl : UserControl
    {
        ObservableCollection<Model.Table> UsingVIP4PersonTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Table> UsingVIP8PersonTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Table> UsingVIP12PersonTables = new ObservableCollection<Model.Table>();

        //ListView lvHienTai = null;
        //ListViewItem lviHienTai = null;
        //Phong phongHienTai = null;

        public UsingVIPTablesUserControl()
        {
            InitializeComponent();

            string result = API.GetAllTableWithStatusAndType("booked", "VIP");
            dynamic stuff = JsonConvert.DeserializeObject(result);

            foreach (var item in stuff)
            {
                if (item.numberOfSeat == 4)
                {
                    UsingVIP4PersonTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                        customer=new Customer() { fullName=item.customer.fullName,phone=item.customer.phone}
                    });
                }
                else if (item.numberOfSeat == 8)
                {
                    UsingVIP8PersonTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                        customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
                    });
                }
                else
                {
                    UsingVIP12PersonTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                        customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
                    });
                };
            }

            ListViewUsingVIP4PersonTable.ItemsSource = UsingVIP4PersonTables;
            ListViewUsingVIP8PersonTable.ItemsSource = UsingVIP8PersonTables;
            ListViewUsingVIP12PersonTable.ItemsSource = UsingVIP12PersonTables;
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

            //    for (int j = 0; j < UsingVIP4PersonTables.Count; j++)
            //    {
            //        ListViewItem lvi1 = ListViewUsingVIP4PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

            //        var dt1 = cp1.ContentTemplate as DataTemplate;
            //        var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
            //        var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);

            //        rt1.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < UsingVIP8PersonTables.Count; j++)
            //    {
            //        ListViewItem lvi2 = ListViewUsingVIP8PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

            //        var dt2 = cp2.ContentTemplate as DataTemplate;
            //        var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
            //        var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);

            //        rt2.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < UsingVIP12PersonTables.Count; j++)
            //    {
            //        ListViewItem lvi3 = ListViewUsingVIP12PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
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

            //var re1 = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == NumberTable.Text).4PersonOrDefault();

            //string maHD = "HD1";
            //string maKM = null;

            //if (DataProvider.Ins.DB.HoaDons.Count() > 0)
            //{
            //    maHD = "HD" + (DataProvider.Ins.DB.HoaDons.Max(x=>x.id) + 1).ToString();
            //}

            //if (DiscountCodeTextBox.Text != "")
            //{
            //    var DSMKM = DataProvider.Ins.DB.DanhSachMaKhuyenMais.Where(x => x.maKhuyenMai == DiscountCodeTextBox.Text).4PersonOrDefault();

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

            //foreach (var room in UsingVIP4PersonTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingVIP4PersonTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewUsingVIP4PersonTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingVIP4PersonTable.ItemsSource = UsingVIP4PersonTables;

            //foreach (var room in UsingVIP8PersonTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingVIP8PersonTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewUsingVIP8PersonTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingVIP8PersonTable.ItemsSource = UsingVIP8PersonTables;

            //foreach (var room in UsingVIP12PersonTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        UsingVIP12PersonTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewUsingVIP12PersonTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewUsingVIP12PersonTable.ItemsSource = UsingVIP12PersonTables;

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
            //    var re = DataProvider.Ins.DB.DanhSachMaKhuyenMais.Where(x => x.maKhuyenMai == DiscountCodeTextBox.Text).4PersonOrDefault();

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
            //var room = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 1 && x.daXoa == 0).4PersonOrDefault();

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
