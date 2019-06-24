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
        ObservableCollection<Model.Food> Foods = new ObservableCollection<Model.Food>();
        ObservableCollection<Model.Bill> Bills = new ObservableCollection<Model.Bill>();
        ObservableCollection<Order> Orders = new ObservableCollection<Order>();


        dynamic stuff;

        public SearchUserControl()
        {
            InitializeComponent();
            lvListBill.ItemsSource = Orders;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 30;
        }

        private async Task Load()
        {
            await Task.Run(() =>
            {
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
                this.Dispatcher.Invoke(() =>
                {
                    while (true)
                    {
                        if (ListViewTable.IsLoaded == true)
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
                            break;
                        }
                    }
                });
            });
        }

        private async Task LoadBill(dynamic stuffbill)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuffbill)
                    {
                        Bills.Add(new Model.Bill()
                        {
                            employeeName = item.employeeName,
                            billNumber = item.billNumber,
                            tableNumber = item.tableNumber,
                            total = item.total,
                            promotion = item.promotion,
                            customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
                        });

                    };
                });
            });
        }

        private async void LoadFood()
        {
            string result = API.GetAllFood();
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        Foods.Add(new Model.Food()
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

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //((ToggleButton)sender).IsChecked
            Table.IsChecked = false;
            Bill.IsChecked = false;
            Food.IsChecked = false;
            ((ToggleButton)sender).IsChecked = true;
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

                for (int j = 0; j < Foods.Count; j++)
                {
                    ListViewItem lvi1 = ListViewFood.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NameFood", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NameFood", cp);
                Model.Food foodSelected = new Model.Food();

                foreach (var item in Foods)
                {
                    if (item.name == tb.Text)
                    {
                        foodSelected = item;
                        break;
                    }
                };

                NameFood.Text = foodSelected.name;
                PriceFood.Text = foodSelected.price;
                Ingredients.Text = foodSelected.ingredients;
                NoteFood.Text = foodSelected.note;

                if (foodSelected.type == "appetizer")
                {
                    TypeFood.Text = "Khai vị";
                }
                else if (foodSelected.type == "dish")
                {
                    TypeFood.Text = "Món chính";
                }
                else
                {
                    TypeFood.Text = "Tráng miệng";
                }
                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
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
                ID.Text = tableSelected.id;
                if (tableSelected.type == "VIP")
                    TypeTable.Text = "VIP";
                else
                    TypeTable.Text = "Tiêu chuẩn";
                NumberOfSeat.Text = "Bàn " + tableSelected.numberOfSeat + " người";
                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void ListViewBill_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {
                var bc = new BrushConverter();

                for (int j = 0; j < Bills.Count; j++)
                {
                    ListViewItem lvi1 = ListViewBill.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NumberBill", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NumberBill", cp);
                Model.Bill billSelected = new Model.Bill();

                foreach (var item in Bills)
                {
                    if (item.billNumber.ToString() == tb.Text)
                    {
                        billSelected = item;
                        break;
                    }
                };

                NumberBill.Text = billSelected.billNumber.ToString();
                NumberTableBill.Text = billSelected.tableNumber.ToString();
                TotalBill.Text = billSelected.total.ToString();
                PromotionBill.Text = billSelected.promotion;
                EmployeeBill.Text = billSelected.employeeName;
                CustomerBill.Text = billSelected.customer.fullName;
                LoadOrderFood(billSelected);

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private async void LoadOrderFood(Bill bill)
        {
            await Task.Run(() =>
            {
                string result = API.GetFoodInBillByBill(bill.billNumber.ToString());
                dynamic stuffFoodInBill = JsonConvert.DeserializeObject(result);

                if (result == "")
                {
                    return;
                }

                this.Dispatcher.Invoke(() =>
                {
                    Orders.Clear();
                    foreach (var item in stuffFoodInBill)
                    {
                        if (item.amount > 0)
                        {
                            Orders.Add(new Order()
                            {
                                name = item.name,
                                price = item.price,
                                amount = item.amount
                            });
                        }
                    };
                });
            });
        }

        private void SearchTable_Click()
        {
            string result = API.GetAllTable();
            stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            Tables.Clear();
            ListViewTable.ItemsSource = Tables;

            Boolean search = false;
            foreach (var item in stuff)
            {
                if (item.number == TbSearchTable.Text)
                {
                    search = true;
                    Tables.Add(new Model.Table()
                    {
                        id = item._id,
                        number = item.number,
                        type = item.type,
                        numberOfSeat = item.numberOfSeat,
                        status = item.status,
                        customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone },
                        note = item.note
                    });
                }
            };
            if (search == false)
            {
                MessageBox.Show("Số bàn bạn nhập không tồn tại!!!");
                HiddenScreen();
                return;
            }
            ResetLayoutTables();
        }

        private async void SearchTableCustomer_Click()
        {
            string result = API.GetAllTableWithCustomer(TbSearchTable.Text);
            stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            Tables.Clear();
            ListViewTable.ItemsSource = Tables;
            await Load();
            if (Tables.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bàn theo yêu cầu của bạn!!!");
                HiddenScreen();

                return;
            }
            ResetLayoutTables();

        }

        private void SearchFood_Click()
        {
            string result = API.GetAllFood();
            stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            Foods.Clear();
            ListViewFood.ItemsSource = Foods;

            Boolean search = false;
            string foodQuery = TbSearchTable.Text.ToUpper();
            foreach (var item in stuff)
            {
                string foodInList = item.name.ToString().ToUpper();
                if (foodInList.IndexOf(foodQuery) != -1 || foodQuery.IndexOf(foodInList) != -1)
                {
                    Foods.Add(new Model.Food()
                    {
                        name = item.name,
                        price = item.price,
                        type = item.type,
                        ingredients = item.ingredients,
                        note = item.note
                    });
                    search = true;
                }
            };
            if (search == false)
            {
                MessageBox.Show("Tên món ăn bạn nhập không tồn tại!!!");
                HiddenScreen();

                return;
            }
            ResetLayoutFood();
        }

        private void SearchBill_Click()
        {
            Bills.Clear();
            ListViewBill.ItemsSource = Bills;

            string result = API.FindOneBill(TbSearchTable.Text);
            dynamic stuffbill = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            try
            {
                Bills.Add(new Model.Bill()
                {
                    billNumber = stuffbill.billNumber,
                    tableNumber = stuffbill.tableNumber,
                    total = stuffbill.total,
                    promotion = stuffbill.promotion,
                    employeeName = stuffbill.employeeName,
                    customer = new Customer() { fullName = stuffbill.customer.fullName, phone = stuffbill.customer.phone }
                });
            }
            catch
            {
                MessageBox.Show("Số hóa đơn bạn nhập không tồn tại!!!");
                HiddenScreen();
                return;
            }
            ResetLayoutBill();
        }

        private async void SearchBillCustomer_Click()
        {
            string result = API.GetAllBillWithCustomer(TbSearchTable.Text);
            dynamic stuffBill = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            Bills.Clear();
            ListViewBill.ItemsSource = Bills;
            await LoadBill(stuffBill);
            if (Bills.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn theo yêu cầu của bạn!!!");
                HiddenScreen();

                return;
            }
            ResetLayoutBill();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Table.IsChecked == true)
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
            if (Food.IsChecked == true)
            {
                SearchFood_Click();
            }
            if (Bill.IsChecked == true)
            {
                try
                {
                    int.Parse(TbSearchTable.Text);

                    SearchBill_Click();
                }
                catch
                {
                    SearchBillCustomer_Click();
                }
            }
        }

        private void HiddenScreen()
        {
            GridTable.Visibility = Visibility.Hidden;
            GridFood.Visibility = Visibility.Hidden;
            GridBill.Visibility = Visibility.Hidden;

        }

        private void ResetLayoutBill()
        {
            HiddenScreen();
            GridBill.Visibility = Visibility.Visible;
            NumberBill.Text = "";
            NumberTableBill.Text = "";
            EmployeeBill.Text = "";
            TotalBill.Text = "";
            PromotionBill.Text = "";
            CustomerBill.Text = "";
            Orders.Clear();
        }

        private void ResetLayoutFood()
        {
            NameFood.Text = "";
            PriceFood.Text = "";
            Ingredients.Text = "";
            NoteFood.Text = "";
            TypeFood.Text = "";
            HiddenScreen();
            GridFood.Visibility = Visibility.Visible;
        }

        private void ResetLayoutTables()
        {
            HiddenScreen();
            GridTable.Visibility = Visibility.Visible;
            NumberTable.Text = "";
            NumberOfSeat.Text = "";
            CustomerName.Text = "";
            Phone.Text = "";
            Note.Text = "";
            Status.Text = "";
            TypeTable.Text = "";
        }

        private void TbSearchTable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearchTable.Text.Length > 0)
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

