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

        ObservableCollection<Model.Food> Food1 = new ObservableCollection<Model.Food>();
        ObservableCollection<Model.Food> Food2 = new ObservableCollection<Model.Food>();
        ObservableCollection<Model.Food> Food3 = new ObservableCollection<Model.Food>();

        Model.Table tableSelected = new Model.Table();

        ListView lvHienTai = null;
        ListViewItem lviHienTai = null;
        dynamic stuff;
        dynamic stuffAllFood;
        Boolean AddFoodCheck = false;

        Boolean DetailFoodCheck = false;

        public UsingVIPTablesUserControl()
        {
            InitializeComponent();


            ListViewUsingVIP4PersonTable.ItemsSource = UsingVIP4PersonTables;
            ListViewUsingVIP8PersonTable.ItemsSource = UsingVIP8PersonTables;
            ListViewUsingVIP12PersonTable.ItemsSource = UsingVIP12PersonTables;
            Load();

            ListViewFood1.ItemsSource = Food1;
            ListViewFood2.ItemsSource = Food2;
            ListViewFood3.ItemsSource = Food3;

            string result = API.GetAllFood();
            stuffAllFood = JsonConvert.DeserializeObject(result);
            LoadFood(stuffAllFood);
        }

        private async void Load()
        {
            string result = API.GetAllTableWithStatusAndType("booked", "VIP");
            stuff = JsonConvert.DeserializeObject(result);

            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        if (item.numberOfSeat == 4)
                        {
                            UsingVIP4PersonTables.Add(new Model.Table()
                            {
                                number = item.number,
                                numberOfSeat = item.numberOfSeat,
                                status = item.status,
                                customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
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

                });
            });
        }

        private async void LoadFood(dynamic stuffFood)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuffFood)
                    {
                        if (item.type == "dish")
                            Food2.Add(new Model.Food()
                            {
                                id = item._id,
                                name = item.name,
                                type = item.type,
                                ingredients = item.ingredients,
                                note = item.note,
                                price = item.price
                            });
                        else if (item.type == "dessert")
                            Food3.Add(new Model.Food()
                            {
                                id = item._id,
                                name = item.name,
                                type = item.type,
                                ingredients = item.ingredients,
                                note = item.note,
                                price = item.price
                            });
                        else
                            Food1.Add(new Model.Food()
                            {
                                id = item._id,
                                name = item.name,
                                type = item.type,
                                ingredients = item.ingredients,
                                note = item.note,
                                price = item.price
                            });

                    };
                });
            });

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 60;
        }

        private void ListViewUsingVIPTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {
                lvHienTai = (ListView)sender;
                lviHienTai = lvi;

                var bc = new BrushConverter();

                for (int j = 0; j < UsingVIP4PersonTables.Count; j++)
                {
                    ListViewItem lvi1 = ListViewUsingVIP4PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);
                    var tbtype1 = (TextBlock)dt1.FindName("TypeTable", cp1);
                    var tbcustomer1 = (TextBlock)dt1.FindName("CustomerName", cp1);

                    rt1.Fill = Brushes.White;
                }

                for (int j = 0; j < UsingVIP8PersonTables.Count; j++)
                {
                    ListViewItem lvi2 = ListViewUsingVIP8PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

                    var dt2 = cp2.ContentTemplate as DataTemplate;
                    var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
                    var tb2 = (TextBlock)dt2.FindName("NumberTable", cp2);

                    rt2.Fill = Brushes.White;
                }

                for (int j = 0; j < UsingVIP12PersonTables.Count; j++)
                {
                    ListViewItem lvi3 = ListViewUsingVIP12PersonTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp3 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi3);

                    var dt3 = cp3.ContentTemplate as DataTemplate;
                    var rt3 = (Rectangle)dt3.FindName("BackGround", cp3);
                    var tb3 = (TextBlock)dt3.FindName("NumberTable", cp3);

                    rt3.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NumberTable", cp);


                foreach (var item in stuff)
                {
                    if (item.number == tb.Text)
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
                        break;
                    }
                };
                NumberTable.Text = tableSelected.number;
                TypeTable.Text = "Bàn " + tableSelected.numberOfSeat + " người";
                CustomerName.Text = tableSelected.customer.fullName;
                CustomerPhone.Text = tableSelected.customer.phone;
                NoteTextBlock.Text = tableSelected.note;

                string result = API.GetTotalInBill(tableSelected.number);
                dynamic total = JsonConvert.DeserializeObject(result);
                Total.Text = total.total;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnThanhToan(object sender, RoutedEventArgs e)
        {
            if (NumberTable.Text == "")
            {
                MessageBox.Show("Chưa chọn bàn!");
                return;
            }
            string result = API.Pay(NumberTable.Text);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (stuff.message != "successfull")
            {
                MessageBox.Show("Thanh toán thất bại!!!");
                return;
            }
            MessageBox.Show("Thanh toán thành công!!!");
            NumberTable.Text = "";
            TypeTable.Text = "";
            CustomerName.Text = "";
            CustomerPhone.Text = "";
            NoteTextBlock.Text = "";
            UsingVIP4PersonTables.Clear();
            UsingVIP8PersonTables.Clear();
            UsingVIP12PersonTables.Clear();
            Load();
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
            CustomerName.Text = tableSelected.customer.fullName;
            CustomerPhone.Text = tableSelected.customer.phone;
            NoteTextBlock.Text = tableSelected.note;

        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            if (AddFoodCheck == false)
            {
                Food2.Clear();
                Food1.Clear();
                Food3.Clear();
                if (NumberTable.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn bàn trước!!!");
                    return;
                }
                string result = API.GetAllFood();
                stuffAllFood = JsonConvert.DeserializeObject(result);
                LoadFood(stuffAllFood);
                Table.Visibility = Visibility.Hidden;
                Food.Visibility = Visibility.Visible;
                AddFood.Content = "Trở về";
                AddFoodCheck = true;
                return;
            }
            else
            {
                Table.Visibility = Visibility.Visible;
                Food.Visibility = Visibility.Hidden;
                AddFood.Content = "Thêm món";
                AddFoodCheck = false;
            }

        }

        private void ListViewFood_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {


                var bc = new BrushConverter();

                for (int j = 0; j < Food1.Count; j++)
                {
                    ListViewItem lvi1 = ListViewFood1.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NameFood", cp1);
                    rt1.Fill = Brushes.White;
                }

                for (int j = 0; j < Food2.Count; j++)
                {
                    ListViewItem lvi2 = ListViewFood2.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp2 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi2);

                    var dt2 = cp2.ContentTemplate as DataTemplate;
                    var rt2 = (Rectangle)dt2.FindName("BackGround", cp2);
                    var tb2 = (TextBlock)dt2.FindName("NameFood", cp2);
                    rt2.Fill = Brushes.White;
                }

                for (int j = 0; j < Food3.Count; j++)
                {
                    ListViewItem lvi3 = ListViewFood3.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp3 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi3);

                    var dt3 = cp3.ContentTemplate as DataTemplate;
                    var rt3 = (Rectangle)dt3.FindName("BackGround", cp3);
                    var tb3 = (TextBlock)dt3.FindName("NameFood", cp3);
                    rt3.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NameFood", cp);
                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");

                Model.Food foodSelected = new Model.Food();

                foreach (var item in stuffAllFood)
                {
                    if (item.name == tb.Text)
                    {
                        foodSelected = new Model.Food()
                        {
                            id = item._id,
                            name = item.name,
                            price = item.price,
                            type = item.type,
                            ingredients = item.ingredients,
                            note = item.note,
                        };
                        break;
                    }
                };

                if (tableSelected == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn trước khi chọn món!!!");
                    return;
                }

                string result = API.AddFoodInBill(tableSelected.number, foodSelected);
                dynamic stuffAddFood = JsonConvert.DeserializeObject(result);


                if (stuffAddFood.message != "Add successfull")
                {
                    MessageBox.Show("Có lỗi sảy ra, vui lòng thử lại!!!");
                    return;
                }
                MessageBox.Show("Thêm món thành công!!!");
                string resulttotal = API.GetTotalInBill(tableSelected.number);
                dynamic total = JsonConvert.DeserializeObject(resulttotal);
                Total.Text = total.total;
                rt.Fill = Brushes.White;
            }
        }

        private void FoodInBill_Click(object sender, RoutedEventArgs e)
        {

            if (DetailFoodCheck == false)
            {
                Food2.Clear();
                Food1.Clear();
                Food3.Clear();
                if (tableSelected.number == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn trước!!!");
                    return;
                }
                string result = API.GetFoodInBill(tableSelected.number);
                dynamic stuffFood = JsonConvert.DeserializeObject(result);
                LoadFood(stuffFood);
                Table.Visibility = Visibility.Hidden;
                Food.Visibility = Visibility.Visible;
                FoodInBill.Content = "Trở về";
                DetailFoodCheck = true;
                return;
            }
            else
            {
                Table.Visibility = Visibility.Visible;
                Food.Visibility = Visibility.Hidden;
                FoodInBill.Content = "Chi tiết";
                DetailFoodCheck = false;
            }
        }

    }
}
