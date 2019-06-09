using Newtonsoft.Json;
using QuanLyNhaHang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        ObservableCollection<Model.Table> Tables = new ObservableCollection<Model.Table>();
        dynamic stuff;

        public SearchUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 30;
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        Tables.Add(new Model.Table()
                        {
                            ID = item._id,
                            number = item.number,
                            numberOfSeat = item.numberOfSeat,
                            type = item.type,
                            status = item.status,
                            note = item.note,
                            time = item.time,
                            customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
                        });
                    };
                });
            });

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < Tables.Count; i++)
                    {
                        if (Tables[i].type == "standard")
                        {
                            ListViewItem lvi1 = ListViewTable.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                            var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                            var dt1 = cp1.ContentTemplate as DataTemplate;
                            var rt1 = (Grid)dt1.FindName("TicketType", cp1);
                            rt1.Background = Brushes.Blue;
                        }
                    };
                });
            });
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //((ToggleButton)sender).IsChecked
            Table.IsChecked = false;
            Bill.IsChecked = false;
            Food.IsChecked = false;
            ((ToggleButton)sender).IsChecked = true;
        }

        private void SearchTable_Click()
        {
            string result = API.GetAllTable();
            stuff = JsonConvert.DeserializeObject(result);

            ListViewTable.ItemsSource = Tables;
            Load();

            Model.Table tableSelected = new Model.Table();

            if (TbSearchTable.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số bàn!!!");
                return;
            }

            Boolean search = false;
            foreach (var item in stuff)
            {
                if (item.number == TbSearchTable.Text)
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
            if (tableSelected.type == "VIP")
                TypeTable.Text = "VIP";
            else
                TypeTable.Text = "Tiêu chuẩn";
            NumberOfSeat.Text = "Bàn " + tableSelected.numberOfSeat + " người";
            CustomerName.Text = tableSelected.customer.fullName;
            Phone.Text = tableSelected.customer.phone;
            Note.Text = tableSelected.note;
            Time.Text = tableSelected.time;
            Status.Text = tableSelected.status;


        }

        private void ListViewTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {


                var bc = new BrushConverter();

                for (int j = 0; j < Tables.Count; j++)
                {
                    ListViewItem lvi1 = ListViewTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NumberTable", cp);
                Model.Table tableSelected = new Model.Table();

                foreach (var item in Tables)
                {
                    if (item.number == tb.Text)
                    {
                        tableSelected = item;
                        break;
                    }
                };

                NumberTable.Text = tableSelected.number;
                CustomerName.Text = tableSelected.customer.fullName;
                Phone.Text = tableSelected.customer.phone;
                Status.Text = tableSelected.status;
                Note.Text = tableSelected.note;
                Time.Text = tableSelected.time;
                ID.Text = tableSelected.ID;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void SearchTableCustomer_Click()
        {
            if (TbSearchTable.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!!!");
                return;
            }
            string result = API.GetAllTableWithCustomer(TbSearchTable.Text);
            stuff = JsonConvert.DeserializeObject(result);

            ListViewTable.ItemsSource = Tables;
            Load();

            Model.Table tableSelected = new Model.Table();
                  
            Boolean search = false;
            foreach (var item in stuff)
            {
                if (item.number == TbSearchTable.Text)
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
                MessageBox.Show("Khách hàng bạn nhập không tồn tại!!!");
                return;
            }
            NumberTable.Text = tableSelected.number;
            if (tableSelected.type == "VIP")
                TypeTable.Text = "VIP";
            else
                TypeTable.Text = "Tiêu chuẩn";
            NumberOfSeat.Text = "Bàn " + tableSelected.numberOfSeat + " người";
            CustomerName.Text = tableSelected.customer.fullName;
            Phone.Text = tableSelected.customer.phone;
            Note.Text = tableSelected.note;
            Time.Text = tableSelected.time;
            Status.Text = tableSelected.status;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Table.IsChecked==true)
            {
                try
                {
                    int.Parse(TbSearchTable.Text);

                    SearchTable_Click();
                }
                catch 
                {
                    SearchTableCustomer_Click();
                }
            }
        }
    }
}

