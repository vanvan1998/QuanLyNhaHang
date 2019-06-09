using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        ObservableCollection<Model.Table> EmptyVIP4PersonTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Table> EmptyVIP8PersonTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Table> EmptyVIP12PersonTables = new ObservableCollection<Model.Table>();
        dynamic stuff;
        public EmptyVIPTablesUserControl()
        {
            InitializeComponent();

            ListViewEmptyVIP4PersonTable.ItemsSource = EmptyVIP4PersonTables;
            ListViewEmptyVIP8PersonTable.ItemsSource = EmptyVIP8PersonTables;
            ListViewEmptyVIP12PersonTable.ItemsSource = EmptyVIP12PersonTables;

            Load();
        }

        private async void Load()
        {
            string result = API.GetAllTableWithStatusAndType("empty", "VIP");
            stuff= JsonConvert.DeserializeObject(result);

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        if (item.numberOfSeat == 4)
                        {
                            EmptyVIP4PersonTables.Add(new Model.Table()
                            {
                                number = item.number,
                                numberOfSeat = item.numberOfSeat,
                                status = item.status,
                            });
                        }
                        else if (item.numberOfSeat == 8)
                        {
                            EmptyVIP8PersonTables.Add(new Model.Table()
                            {
                                number = item.number,
                                numberOfSeat = item.numberOfSeat,
                                status = item.status,
                            });
                        }
                        else
                        {
                            EmptyVIP12PersonTables.Add(new Model.Table()
                            {
                                number = item.number,
                                numberOfSeat = item.numberOfSeat,
                                status = item.status,
                            });
                        };
                    }

                });
            });

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewEmptyVIPTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {
                var bc = new BrushConverter();

                for (int j = 0; j < EmptyVIP4PersonTables.Count; j++)
                {
                    ListViewItem lvi1 = ListViewEmptyVIP4PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);
                    var tbtype1 = (TextBlock)dt1.FindName("TypeTable", cp1);

                    rt1.Fill = Brushes.White;
                }

                for (int j = 0; j < EmptyVIP8PersonTables.Count; j++)
                {
                    ListViewItem lvi2 = ListViewEmptyVIP8PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

                    var dt2 = cp2.ContentTemplate as DataTemplate;
                    var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
                    var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);
                    var tbtype2 = (TextBlock)dt2.FindName("TypeTable", cp2);

                    rt2.Fill = Brushes.White;
                }

                for (int j = 0; j < EmptyVIP12PersonTables.Count; j++)
                {
                    ListViewItem lvi3 = ListViewEmptyVIP12PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
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

                //foreach (var room in DataProvider.Ins.DB.Phongs.ToList())
                //{
                //    if (tb.Text == room.soPhong)
                //    {
                //        phongHienTai = room;
                //        NumberTable.Text = room.soPhong;
                //        TypeTable.Text = room.loaiPhong;
                //        break;
                //    }
                //}
                NumberTable.Text = tb.Text;
                TypeTable.Text = "Bàn " + tbtype.Text + " người";

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }

        }


        private void BtnDatBan(object sender, RoutedEventArgs e)
        {

            if (NumberTable.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bàn trước!");
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

            Model.Table tableBook = new Model.Table();
            tableBook.number = NumberTable.Text;
            tableBook.note = NoteTextBox.Text;
            tableBook.status = "booked";
            tableBook.time = TimeTextBox.Text;

            tableBook.customer = new Customer() { fullName = CustomerNameTextBox.Text, phone = CustomerPhone.Text };

            string result = API.BookTable(tableBook);
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "Table update successfully!")
            {
                MessageBox.Show("Đặt bàn thành công!!!");
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình đặt bàn, vui lòng thử lại!!!");
            }

            EmptyVIP12PersonTables.Clear();
            EmptyVIP8PersonTables.Clear();
            EmptyVIP4PersonTables.Clear();
            Load();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Model.Table tableSelected = new Model.Table();

            if (TbSearch.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số bàn!!!");
                return;
            }

            Boolean search = false;
            foreach (var item in stuff)
            {
                if (item.number == TbSearch.Text)
                {
                    tableSelected = new Model.Table()
                    {
                        ID = item._id,
                        number = item.number,
                        type = item.type,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                        customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone },
                        note = item.note,
                        time = item.time
                    };
                    search = true;
                    break;
                }
            };
            if (search == false)
            {
                MessageBox.Show("Số bàn bạn nhập không tồn tại!!!");
                return;
            }
            NumberTable.Text = tableSelected.number;
            TypeTable.Text = "Bàn " + tableSelected.numberOfSeat + " người";

        }
    }
}
