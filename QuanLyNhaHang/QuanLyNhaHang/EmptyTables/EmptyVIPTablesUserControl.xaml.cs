using System;
using System.Collections.Generic;
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

namespace QuanLyNhaHang.EmptyTables
{
    /// <summary>
    /// Interaction logic for UserControlVIPUsedTable.xaml
    /// </summary>
    public partial class EmptyVIPTablesUserControl : UserControl
    {
        List<Model.Table> EmptyVIPSingleTables = new List<Model.Table>();
        List<Model.Table> EmptyVIPCoupleTables = new List<Model.Table>();
        List<Model.Table> EmptyVIPGroupTables = new List<Model.Table>();

        public EmptyVIPTablesUserControl()
        {
            InitializeComponent();

            string result = API.getAllTableWithStatusAndType("empty", "VIP");
            dynamic stuff = JsonConvert.DeserializeObject(result);

            foreach (var item in stuff)
            {
                if (item.numberOfSeat == 4)
                {
                    EmptyVIPSingleTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                    });
                }
                else if (item.numberOfSeat == 8)
                {
                    EmptyVIPCoupleTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                    });
                }
                else
                {
                    EmptyVIPGroupTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                    });
                };
            }

            ListViewEmptyVIPSingleTable.ItemsSource = EmptyVIPSingleTables;
            ListViewEmptyVIPCoupleTable.ItemsSource = EmptyVIPCoupleTables;
            ListViewEmptyVIPGroupTable.ItemsSource = EmptyVIPGroupTables;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewEmptyVIPTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
        //    if (((ListView)sender).SelectedIndex == -1)
        //    {
        //        return;
        //    }

        //    if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
        //    {
        //        var bc = new BrushConverter();

        //        for (int j = 0; j < EmptyVIPSingleTables.Count; j++)
        //        {
        //            ListViewItem lvi1 = ListViewEmptyVIPSingleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
        //            var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

        //            var dt1 = cp1.ContentTemplate as DataTemplate;
        //            var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
        //            var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);

        //            rt1.Fill = Brushes.White;
        //        }

        //        for (int j = 0; j < EmptyVIPCoupleTables.Count; j++)
        //        {
        //            ListViewItem lvi2 = ListViewEmptyVIPCoupleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
        //            var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

        //            var dt2 = cp2.ContentTemplate as DataTemplate;
        //            var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
        //            var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);

        //            rt2.Fill = Brushes.White;
        //        }

        //        for (int j = 0; j < EmptyVIPGroupTables.Count; j++)
        //        {
        //            ListViewItem lvi3 = ListViewEmptyVIPGroupTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
        //            var cp3 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi3);

        //            var dt3 = cp3.ContentTemplate as DataTemplate;
        //            var rt3 = (Rectangle)dt3.FindName("BackGround", cp3);
        //            var tb3 = (TextBlock)dt3.FindName("NumberTable", cp3);

        //            rt3.Fill = Brushes.White;
        //        }

        //        var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

        //        var dt = cp.ContentTemplate as DataTemplate;
        //        var rt = (Rectangle)dt.FindName("BackGround", cp);
        //        var tb = (TextBlock)dt.FindName("NumberTable", cp);

        //        foreach (var room in DataProvider.Ins.DB.Phongs.ToList())
        //        {
        //            if (tb.Text == room.soPhong)
        //            {
        //                phongHienTai = room;
        //                NumberTable.Text = room.soPhong;
        //                TypeTable.Text = room.loaiPhong;
        //                break;
        //            }
        //        }

        //        rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
        //    }

        }


        private void BtnDatPhong(object sender, RoutedEventArgs e)
        {
            //if (NumberTable.Text == "")
            //{
            //    MessageBox.Show("Vui lòng chọn phòng trước!");
            //    return;
            //}

            //if (CustomerNameTextBox.Text == "")
            //{
            //    MessageBox.Show("Chưa nhập tên khách hàng!");
            //    return;
            //}

            //if (CustomerIDTextBox.Text == "")
            //{
            //    MessageBox.Show("Chưa nhập CMND khách hàng!");
            //    return;
            //}

            //string maKH = "KH1";

            //if (DataProvider.Ins.DB.KhachHangs.Count() > 0)
            //{
            //    maKH = "KH" + (DataProvider.Ins.DB.KhachHangs.Max(x=>x.id) + 1).ToString();
            //}

            //KhachHang khachHang = new KhachHang
            //{
            //    hoTen = CustomerNameTextBox.Text,
            //    cmnd = CustomerIDTextBox.Text,
            //    maKhachHang = maKH
            //};

            ////thêm thông tin khách hàng vừa nhập
            //DataProvider.Ins.DB.KhachHangs.Add(khachHang);
            //DataProvider.Ins.DB.SaveChanges();

            //// thêm thông tin vào phòng vừa chọn
            //phongHienTai.maKhachHang = khachHang.maKhachHang;
            //phongHienTai.tinhTrang = 1;
            //if (NoteTextBox.Text == "")
            //{
            //    phongHienTai.ghiChu = null;
            //}
            //else
            //{
            //    phongHienTai.ghiChu = NoteTextBox.Text;
            //}
            //phongHienTai.thoiGianBatDau = DateTime.Now;

            //foreach (var room in EmptyVIPSingleTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyVIPSingleTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewEmptyVIPSingleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyVIPSingleTable.ItemsSource = EmptyVIPSingleTables;

            //foreach (var room in EmptyVIPCoupleTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyVIPCoupleTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewEmptyVIPCoupleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyVIPCoupleTable.ItemsSource = EmptyVIPCoupleTables;

            //foreach (var room in EmptyVIPGroupTables)
            //{
            //    if (room.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyVIPGroupTables.Remove(room);
            //        break;
            //    }
            //}

            //ListViewEmptyVIPGroupTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyVIPGroupTable.ItemsSource = EmptyVIPGroupTables;

            //DataProvider.Ins.DB.SaveChanges();
            //MessageBox.Show("Đặt phòng thành công!");

            //NumberTable.Text = "";
            //TypeTable.Text = "";
            //CustomerNameTextBox.Text = "";
            //CustomerIDTextBox.Text = "";
            //NoteTextBox.Text = "";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
        //    var room = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 0 && x.daXoa == 0).SingleOrDefault();

        //    if (room != null)
        //    {
        //        phongHienTai = room;
        //        NumberTable.Text = room.soPhong;
        //        TypeTable.Text = room.loaiPhong;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Số phòng không đúng!");
        //    }
        }
    }
}
