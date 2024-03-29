﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
namespace QuanLyNhaHang.Setting
{
    /// <summary>
    /// Interaction logic for SettingTableUserControl.xaml
    /// </summary>
    public partial class SettingTableUserControl : UserControl
    {
        ObservableCollection<Model.Table> Tables = new ObservableCollection<Model.Table>();
        dynamic stuff;
        public SettingTableUserControl()
        {
            InitializeComponent();

            ListViewTable.ItemsSource = Tables;
            Load();
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                string result = API.GetAllTable();
                stuff = JsonConvert.DeserializeObject(result);

                if (result == "")
                {
                    return;
                }

                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        Tables.Add(new Model.Table()
                        {
                            id = item._id,
                            number = item.number,
                            numberOfSeat = item.numberOfSeat,
                            type = item.type,
                            status = item.status,
                            note = item.note,
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 40;
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
                if (tableSelected.type == "standard")
                {
                    TypeTable.SelectedIndex = 0;
                }
                else
                {
                    TypeTable.SelectedIndex = 1;
                }

                if (tableSelected.numberOfSeat == 4)
                {
                    NumberOfSeat.SelectedIndex = 0;
                }
                else if (tableSelected.numberOfSeat == 8)
                {
                    NumberOfSeat.SelectedIndex = 1;
                }
                else
                {
                    NumberOfSeat.SelectedIndex = 2;
                }

                if (tableSelected.status == "empty")
                {
                    Status.SelectedIndex = 0;
                }
                else
                {
                    Status.SelectedIndex = 1;
                }
                Note.Text = tableSelected.note;
                ID.Text = tableSelected.id;

                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Model.Table tableNew = new Model.Table();
            tableNew.number = NumberTable.Text;
            if (TypeTable.SelectedIndex == 0)
            {
                tableNew.type = "standard";
            }
            else
            {
                tableNew.type = "VIP";
            }

            if (NumberOfSeat.SelectedIndex == 0)
            {
                tableNew.numberOfSeat = 4;
            }
            else if (NumberOfSeat.SelectedIndex == 1)
            {
                tableNew.numberOfSeat = 8;
            }
            else
            {
                tableNew.numberOfSeat = 12;
            }

            if (Status.SelectedIndex == 0)
            {
                tableNew.status = "empty";
                tableNew.customer = new Customer() { fullName = "", phone = "" };
            }
            else
            {
                tableNew.status = "booked";
                if (CustomerName.Text == "" || Phone.Text == "")
                {
                    MessageBox.Show("Thông tin khách hàng không được để trống!!!");
                    return;
                }
                tableNew.customer = new Customer() { fullName = CustomerName.Text, phone = Phone.Text };
                tableNew.note = Note.Text;
            }
            foreach (var item in Tables)
            {
                if (item.number == NumberTable.Text)
                {
                    MessageBox.Show("Số bàn đã có!!!\n Bạn vui lòng chọn số bàn khác!");
                    return;
                }
            };

            string result = API.CreateTable(tableNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            if (stuff.message == "create successful")
            {
                MessageBox.Show("Tạo bàn thành công!!!");
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình tạo bàn, vui lòng thử lại!!!");
            }

            Tables.Clear();
            Load();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi xóa!!!");
                return;
            }
            string result = API.DeleteTable(ID.Text);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            if (stuff.message == "Table deleted successfully!")
            {
                MessageBox.Show("Xóa bàn thành công!!!");
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình xóa, vui lòng thử lại!!!");
            }
            Tables.Clear();
            Load();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            Model.Table tableNew = new Model.Table();
            if (ID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi cập nhật!!!");
                return;
            }
            tableNew.id = ID.Text;
            tableNew.number = NumberTable.Text;
            if (TypeTable.SelectedIndex == 0)
            {
                tableNew.type = "standard";
            }
            else
            {
                tableNew.type = "VIP";
            }

            if (NumberOfSeat.SelectedIndex == 0)
            {
                tableNew.numberOfSeat = 4;
            }
            else if (NumberOfSeat.SelectedIndex == 1)
            {
                tableNew.numberOfSeat = 8;
            }
            else
            {
                tableNew.numberOfSeat = 12;
            }

            if (Status.SelectedIndex == 0)
            {
                tableNew.status = "empty";
                tableNew.customer = new Customer() { fullName = "", phone = "" };
            }
            else
            {
                tableNew.status = "booked";
                if (CustomerName.Text == "" || Phone.Text == "")
                {
                    MessageBox.Show("Thông tin khách hàng không được để trống!!!");
                    return;
                }
                tableNew.customer = new Customer() { fullName = CustomerName.Text, phone = Phone.Text };
                tableNew.note = Note.Text;
            }
            foreach (var item in Tables)
            {
                if (item.number == NumberTable.Text && item.id != ID.Text)
                {
                    MessageBox.Show("Số bàn đã có!!!\n Bạn vui lòng chọn số bàn khác!");
                    return;
                }
            };

            string result = API.UpdateTable(tableNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            if (stuff.message == "Table update successfully!")
            {
                MessageBox.Show("Cập nhật thông tin bàn thành công!!!");
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình cập nhật, vui lòng thử lại!!!");
            }
            Tables.Clear();
            Load();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Model.Table tableSelected = new Model.Table();

            Boolean search = false;
            foreach (var item in stuff)
            {
                if (item.number == TbSearch.Text)
                {
                    tableSelected = new Model.Table()
                    {
                        id = item._id,
                        number = item.number,
                        type = item.type,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                        customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone },
                        note = item.note,
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
            CustomerName.Text = tableSelected.customer.fullName;
            Phone.Text = tableSelected.customer.phone;
            if (tableSelected.type == "standard")
            {
                TypeTable.SelectedIndex = 0;
            }
            else
            {
                TypeTable.SelectedIndex = 1;
            }

            if (tableSelected.numberOfSeat == 4)
            {
                NumberOfSeat.SelectedIndex = 0;
            }
            else if (tableSelected.numberOfSeat == 8)
            {
                NumberOfSeat.SelectedIndex = 1;
            }
            else
            {
                NumberOfSeat.SelectedIndex = 2;
            }

            if (tableSelected.status == "empty")
            {
                Status.SelectedIndex = 0;
            }
            else
            {
                Status.SelectedIndex = 1;
            }
            Note.Text = tableSelected.note;
            ID.Text = tableSelected.id;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearch.Text.Length > 0)
            {
                btnSearch.IsEnabled = true;
            }
            else
            {
                btnSearch.IsEnabled = false;
            }
        }
    }
}
