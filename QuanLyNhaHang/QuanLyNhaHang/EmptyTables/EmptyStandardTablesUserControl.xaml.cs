using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for UserControlStandardUsedTable.xaml
    /// </summary>
    public partial class EmptyStandardTablesUserControl : UserControl
    {
        List<Model.Table> EmptyStandardSingleTables = new List<Model.Table>();
        List<Model.Table> EmptyStandardCoupleTables = new List<Model.Table>();
        List<Model.Table> EmptyStandardGroupTables = new List<Model.Table>();

        private Model.Table tableCurrent = null;
        const string SERVER = "http://localhost:3000/api";

        public EmptyStandardTablesUserControl()
        {
            InitializeComponent();

            //TODO: phải làm 1 stask mới ở đây

            //Ví dụ về lấy danh sách bàn
            string result = GET(SERVER + "/Tables");
            dynamic stuff = JsonConvert.DeserializeObject(result);

            foreach (var item in stuff)
            {
                EmptyStandardSingleTables.Add(new Model.Table()
                {
                    number = item.number,
                    info = item.info,
                    status = item.status,
                    customer = new Customer() {
                        fullName = item.fullName,
                        phone = item.phone,
                        timeOrder = item.timeOrder
                    },
                });
            }

            ListViewEmptyStandardSingleTable.ItemsSource = EmptyStandardSingleTables;
            //ListViewEmptyStandardCoupleTable.ItemsSource = EmptyStandardCoupleTables;
            //ListViewEmptyStandardGroupTable.ItemsSource = EmptyStandardGroupTables;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewEmptyStandardTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //if (((ListView)sender).SelectedIndex == -1)
            //{
            //    return;
            //}

            //if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            //{
            //    var bc = new BrushConverter();

            //    for (int j = 0; j < EmptyStandardSingleTables.Count; j++)
            //    {
            //        ListViewItem lvi1 = ListViewEmptyStandardSingleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

            //        var dt1 = cp1.ContentTemplate as DataTemplate;
            //        var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
            //        var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);

            //        rt1.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < EmptyStandardCoupleTables.Count; j++)
            //    {
            //        ListViewItem lvi2 = ListViewEmptyStandardCoupleTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
            //        var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

            //        var dt2 = cp2.ContentTemplate as DataTemplate;
            //        var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
            //        var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);

            //        rt2.Fill = Brushes.White;
            //    }

            //    for (int j = 0; j < EmptyStandardGroupTables.Count; j++)
            //    {
            //        ListViewItem lvi3 = ListViewEmptyStandardGroupTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
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
            //            break;
            //        }
            //    }

            //    rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            //}
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
            //    maKH = "KH" + (DataProvider.Ins.DB.KhachHangs.Max(x => x.id) + 1).ToString();
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
            //if(NoteTextBox.Text == "")
            //{
            //    phongHienTai.ghiChu = null;
            //}
            //else
            //{
            //    phongHienTai.ghiChu = NoteTextBox.Text;
            //}
            //phongHienTai.thoiGianBatDau = DateTime.Now;

            //foreach (var table in EmptyStandardSingleTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyStandardSingleTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewEmptyStandardSingleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyStandardSingleTable.ItemsSource = EmptyStandardSingleTables;

            //foreach (var table in EmptyStandardCoupleTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyStandardCoupleTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewEmptyStandardCoupleTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyStandardCoupleTable.ItemsSource = EmptyStandardCoupleTables;

            //foreach (var table in EmptyStandardGroupTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyStandardGroupTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewEmptyStandardGroupTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyStandardGroupTable.ItemsSource = EmptyStandardGroupTables;

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
            //var table = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 0 && x.daXoa == 0  ).SingleOrDefault();

            //if (table != null)
            //{
            //    phongHienTai = table;
            //    NumberTable.Text = table.soPhong;
            //    TypeTable.Text = table.loaiPhong;
            //}
            //else
            //{
            //    MessageBox.Show("Số phòng không đúng!");
            //}
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
    }
}
