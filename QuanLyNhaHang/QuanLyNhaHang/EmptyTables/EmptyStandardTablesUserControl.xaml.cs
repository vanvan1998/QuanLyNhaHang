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
        List<Model.Table> EmptyStandard4PersonTables = new List<Model.Table>();
        List<Model.Table> EmptyStandard8PersonTables = new List<Model.Table>();
        List<Model.Table> EmptyStandard12PersonTables = new List<Model.Table>();

        private Model.Table tableSelected = null;

        public EmptyStandardTablesUserControl()
        {
            InitializeComponent();

            //TODO: phải làm 1 stask mới ở đây

            string result = API.GetAllTableWithStatusAndType("empty", "standard");
            dynamic stuff = JsonConvert.DeserializeObject(result);

            foreach (var item in stuff)
            {
                if (item.numberOfSeat == 4) { 
                EmptyStandard4PersonTables.Add(new Model.Table()
                {
                    number = item.number,
                    numberOfSeat = item.numberOfSeat,
                    status = item.status,
                });
                }
                else if(item.numberOfSeat == 8)
                {
                    EmptyStandard8PersonTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                    });
                }
                else
                {
                    EmptyStandard12PersonTables.Add(new Model.Table()
                    {
                        number = item.number,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                    });
                };
            }

            ListViewEmptyStandard4PersonTable.ItemsSource = EmptyStandard4PersonTables;
            ListViewEmptyStandard8PersonTable.ItemsSource = EmptyStandard8PersonTables;
            ListViewEmptyStandard12PersonTable.ItemsSource = EmptyStandard12PersonTables;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewEmptyStandardTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {
                var bc = new BrushConverter();

                for (int j = 0; j < EmptyStandard4PersonTables.Count; j++)
                {
                    ListViewItem lvi1 = ListViewEmptyStandard4PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);
                    var tbtype1 = (TextBlock)dt1.FindName("TypeTable", cp1);

                    rt1.Fill = Brushes.White;
                }

                for (int j = 0; j < EmptyStandard8PersonTables.Count; j++)
                {
                    ListViewItem lvi2 = ListViewEmptyStandard8PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

                    var dt2 = cp2.ContentTemplate as DataTemplate;
                    var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
                    var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);
                    var tbtype2 = (TextBlock)dt2.FindName("TypeTable", cp2);

                    rt2.Fill = Brushes.White;
                }

                for (int j = 0; j < EmptyStandard12PersonTables.Count; j++)
                {
                    ListViewItem lvi3 = ListViewEmptyStandard12PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp3 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi3);

                    var dt3 = cp3.ContentTemplate as DataTemplate;
                    var rt3 = (Rectangle)dt3.FindName("BackGround", cp3);
                    var tb3 = (TextBlock)dt3.FindName("NumberTable", cp3);
                    var tbtype3 = (TextBlock)dt3.FindName("TypeTable", cp3);

                    rt3.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NumberTable", cp);
                var tbtype = (TextBlock)dt.FindName("TypeTable", cp);

                /*foreach (var table in DataProvider.Ins.DB.Phongs.ToList())
                {
                    if (tb.Text == table.soPhong)
                    {
                        phongHienTai = table;
                        NumberTable.Text = table.soPhong;
                        TypeTable.Text = table.loaiPhong;
                        break;
                    }
                }*/

                /*string result = API.GetAllTableWithStatusAndType(tbtype.Text, tb.Text);
                dynamic stuff = JsonConvert.DeserializeObject(result);*/
                NumberTable.Text = tb.Text;
                TypeTable.Text ="Bàn "+ tbtype.Text +" người";
                //tableSelected = stuff;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnDatPhong(object sender, RoutedEventArgs e)
        {

            if (NumberTable.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phòng trước!");
                return;
            }

            if (CustomerNameTextBox.Text == "")
            {
                MessageBox.Show("Chưa nhập tên khách hàng!");
                return;
            }

            if (CustomerPhone.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại khách hàng!");
                return;
            }

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
            //if (NoteTextBox.Text == "")
            //{
            //    phongHienTai.ghiChu = null;
            //}
            //else
            //{
            //    phongHienTai.ghiChu = NoteTextBox.Text;
            //}
            //phongHienTai.thoiGianBatDau = DateTime.Now;

            //foreach (var table in EmptyStandard4PersonTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyStandard4PersonTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewEmptyStandard4PersonTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyStandard4PersonTable.ItemsSource = EmptyStandard4PersonTables;

            //foreach (var table in EmptyStandard8PersonTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyStandard8PersonTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewEmptyStandard8PersonTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyStandard8PersonTable.ItemsSource = EmptyStandard8PersonTables;

            //foreach (var table in EmptyStandard12PersonTables)
            //{
            //    if (table.soPhong == phongHienTai.soPhong)
            //    {
            //        EmptyStandard12PersonTables.Remove(table);
            //        break;
            //    }
            //}

            //ListViewEmptyStandard12PersonTable.ClearValue(ListView.ItemsSourceProperty);
            //ListViewEmptyStandard12PersonTable.ItemsSource = EmptyStandard12PersonTables;

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
            //var table = DataProvider.Ins.DB.Phongs.Where(x => x.soPhong == TbSearch.Text && x.tinhTrang == 0 && x.daXoa == 0  ).4PersonOrDefault();

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
    }
}
