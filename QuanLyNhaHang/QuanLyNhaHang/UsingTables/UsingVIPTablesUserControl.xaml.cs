﻿using System;
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
    /// 

    public partial class UsingVIPTablesUserControl : UserControl
    {
        ObservableCollection<Model.Table> AllTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Food> AllFoods = new ObservableCollection<Model.Food>();
        ObservableCollection<Order> Orders = new ObservableCollection<Order>();


        ObservableCollection<Model.Table> UsingVIP4PersonTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Table> UsingVIP8PersonTables = new ObservableCollection<Model.Table>();
        ObservableCollection<Model.Table> UsingVIP12PersonTables = new ObservableCollection<Model.Table>();

        ObservableCollection<Model.Food> Food1 = new ObservableCollection<Model.Food>();
        ObservableCollection<Model.Food> Food2 = new ObservableCollection<Model.Food>();
        ObservableCollection<Model.Food> Food3 = new ObservableCollection<Model.Food>();

        List<Promotion> Promotions = new List<Promotion>();

        Model.Table tableSelected = null;
        Model.Food foodSelected = null;

        public UsingVIPTablesUserControl()
        {
            InitializeComponent();

            ListViewUsingVIP4PersonTable.ItemsSource = UsingVIP4PersonTables;
            ListViewUsingVIP8PersonTable.ItemsSource = UsingVIP8PersonTables;
            ListViewUsingVIP12PersonTable.ItemsSource = UsingVIP12PersonTables;

            ListViewFood1.ItemsSource = Food1;
            ListViewFood2.ItemsSource = Food2;
            ListViewFood3.ItemsSource = Food3;

            lvListBill.ItemsSource = Orders;

            LoadAlltable();
            LoadAllFood();
            LoadPromotions();
        }

        private async void LoadAlltable()
        {
            await Task.Run(() =>
            {
                string result = API.GetAllTableWithStatusAndType("booked", "VIP");
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        AllTables.Add(new Model.Table()
                        {
                            id = item._id,
                            number = item.number,
                            numberOfSeat = item.numberOfSeat,
                            status = item.status,
                            customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
                        });
                        if (item.numberOfSeat == 4)
                        {
                            UsingVIP4PersonTables.Add(new Model.Table()
                            {
                                id = item._id,
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
                                id = item._id,
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
                                id = item._id,
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

        private async void LoadOrders()
        {
            await Task.Run(() =>
            {
                string result = API.GetFoodInBill(tableSelected.number);
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    Orders.Clear();
                    foreach (var item in stuff)
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

        private async void LoadPromotions()
        {
            await Task.Run(() =>
            {
                string result = API.GetPromotions();
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    Promotions.Clear();
                    foreach (var item in stuff)
                    {
                        Promotions.Add(new Promotion()
                        {
                            code = item.code,
                            type = item.type,
                            value = item.value,
                            rule = item.rule
                        });
                    };
                });
            });

        }

        private async void LoadAllFood()
        {
            await Task.Run(() =>
            {
                string result = API.GetAllFood();
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        AllFoods.Add(new Model.Food()
                        {
                            id = item._id,
                            name = item.name,
                            type = item.type,
                            ingredients = item.ingredients,
                            note = item.note,
                            price = item.price
                        });

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
                ListView ListViewSelected = (ListView)sender;

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

                if (ListViewSelected.Name == "ListViewUsingVIP4PersonTable")
                {
                    foreach (var item in UsingVIP4PersonTables)
                    {
                        if (item.number == tb.Text)
                        {
                            tableSelected = item;
                            break;
                        }
                    }
                }
                else if (ListViewSelected.Name == "ListViewUsingVIP8PersonTable")
                {
                    foreach (var item in UsingVIP8PersonTables)
                    {
                        if (item.number == tb.Text)
                        {
                            tableSelected = item;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in UsingVIP12PersonTables)
                    {
                        if (item.number == tb.Text)
                        {
                            tableSelected = item;
                            break;
                        }
                    }
                }

                UpdateBillLayout();

                AddFood.IsEnabled = true;
                BtnPay.IsEnabled = true;
                DiscountCodeTextBox.IsEnabled = true;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private async void UpdateToTalOfTableSelected()
        {
            await Task.Run(() =>
            {
                string result = API.GetTotalInBill(tableSelected.number);
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);
                this.Dispatcher.Invoke(() =>
                {
                    tableSelected.total = stuff.total;
                    Total.Text = tableSelected.total.ToString();
                });
            });
        }

        private void Pay(object sender, RoutedEventArgs e)
        {
            string result = API.Pay(NumberTable.Text, DiscountCodeTextBox.Text, Total.Text);
            if (result == "")
            {
                return;
            }
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (stuff.message != "successfull")
            {
                MessageBox.Show("Thanh toán thất bại!!!");
                return;
            }

            if (tableSelected.numberOfSeat == 4)
            {
                foreach (var item in UsingVIP4PersonTables)
                {
                    if (tableSelected.number == item.number)
                    {
                        UsingVIP4PersonTables.Remove(item);
                        break;
                    }
                }
            }
            else if (tableSelected.numberOfSeat == 8)
            {
                foreach (var item in UsingVIP8PersonTables)
                {
                    if (tableSelected.number == item.number)
                    {
                        UsingVIP8PersonTables.Remove(item);
                        break;
                    }
                }
            }
            else
            {
                foreach (var item in UsingVIP12PersonTables)
                {
                    if (tableSelected.number == item.number)
                    {
                        UsingVIP12PersonTables.Remove(item);
                        break;
                    }
                }
            }

            ResetBillLayout();
            MessageBox.Show("Thanh toán thành công!!!");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Boolean isExistTable = false;

            foreach (var item in AllTables)
            {
                if (item.number == TbSearch.Text)
                {
                    tableSelected = item;
                    isExistTable = true;
                    break;
                }
            }
            if (!isExistTable)
            {
                MessageBox.Show("Số bàn bạn nhập không tồn tại!!!");
            }
            else
            {
                UpdateBillLayout();
            }
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            if (AddFood.Content.ToString() == "Thêm món")
            {
                Table.Visibility = Visibility.Hidden;
                Food.Visibility = Visibility.Visible;
                AddFood.Content = "Trở về";
            }
            else
            {
                Table.Visibility = Visibility.Visible;
                Food.Visibility = Visibility.Hidden;
                AddFood.Content = "Thêm món";
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
                ListView ListViewSelected = (ListView)sender;
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

                if (ListViewSelected.Name == "ListViewFood1")
                {
                    foreach (var item in Food1)
                    {
                        if (item.name == tb.Text)
                        {
                            foodSelected = item;
                            break;
                        }
                    }
                }
                else if (ListViewSelected.Name == "ListViewFood2")
                {
                    foreach (var item in Food2)
                    {
                        if (item.name == tb.Text)
                        {
                            foodSelected = item;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in Food3)
                    {
                        if (item.name == tb.Text)
                        {
                            foodSelected = item;
                            break;
                        }
                    }
                }

                string result = API.AddFoodInBill(tableSelected.number, foodSelected);
                if (result == "")
                {
                    return;
                }
                dynamic stuffAddFood = JsonConvert.DeserializeObject(result);

                if (stuffAddFood.message != "successfull")
                {
                    MessageBox.Show("Có lỗi sảy ra, vui lòng thử lại!!!");
                }
                else
                {
                    MessageBox.Show("Thêm món thành công!!!");
                    UpdateBillLayout();
                    rt.Fill = Brushes.White;
                }
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearch.Text.Length > 0)
            {
                BtnSearch.IsEnabled = true;
            }
            else
            {
                BtnSearch.IsEnabled = false;
            }
        }

        private async void UpdateBillLayout()
        {
            NumberTable.Text = tableSelected.number;
            TypeTable.Text = "Bàn " + tableSelected.numberOfSeat + " người";
            CustomerName.Text = tableSelected.customer.fullName;
            CustomerPhone.Text = tableSelected.customer.phone;
            NoteTextBlock.Text = tableSelected.note;
            string result = API.GetFee("VIP");
            dynamic stuffFee = JsonConvert.DeserializeObject(result);
            int fee = stuffFee.fee;
            Fee.Text = (fee * tableSelected.numberOfSeat).ToString();

            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    UpdateToTalOfTableSelected();
                    LoadOrders();
                });
            });
        }

        private void ResetBillLayout()
        {
            Orders.Clear();
            NumberTable.Text = "";
            TypeTable.Text = "";
            CustomerName.Text = "";
            CustomerPhone.Text = "";
            NoteTextBlock.Text = "";
            Total.Text = "";

            AddFood.IsEnabled = false;
            BtnPay.IsEnabled = false;
            DiscountCodeTextBox.IsEnabled = false;
        }

        private void DiscountCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool exist = false;
            Promotion promotion = null;

            foreach (Promotion item in Promotions)
            {
                if (DiscountCodeTextBox.Text == item.code)
                {
                    if (item.active == true)
                    {
                        promotion = item;
                        exist = true;
                        break;
                    }
                }
            }
            if (exist)
            {
                if (promotion.type == "percent")
                {
                    Total.Text = (tableSelected.total * (100 - promotion.value) / 100).ToString();
                }
                else
                {
                    Total.Text = (tableSelected.total - promotion.value).ToString();
                }
            }
            else
            {
                Total.Text = tableSelected.total.ToString();
            }
        }

        private async void IncreaseFood_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodName = ((TextBlock)((Grid)((Button)sender).Parent).Children[0]).Text;

            foreach (Order order in Orders)
            {
                if (order.name == selectedFoodName)
                {
                    order.amount++;
                    lvListBill.Items.Refresh();
                    break;
                }
            }

            foreach (Food item in AllFoods)
            {
                if (item.name == selectedFoodName)
                {
                    foodSelected = item;
                    break;
                }
            }
            await Task.Run(() =>
            {
                string result = API.IncreaseAmountFood(tableSelected.number, foodSelected);
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    UpdateBillLayout();
                });
            });
        }

        private async void DecreaseFood_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodName = ((TextBlock)((Grid)((Button)sender).Parent).Children[0]).Text;

            foreach (Order order in Orders)
            {
                if (order.name == selectedFoodName)
                {
                    if (order.amount > 0)
                    {
                        order.amount--;
                    }
                    else
                    {
                        Orders.Remove(order);
                    }

                    lvListBill.Items.Refresh();
                    break;
                }
            }

            foreach (Food item in AllFoods)
            {
                if (item.name == selectedFoodName)
                {
                    foodSelected = item;
                    break;
                }
            }
            await Task.Run(() =>
            {
                string result = API.DecreaseAmountFood(tableSelected.number, foodSelected);
                if (result == "")
                {
                    return;
                }
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    UpdateBillLayout();
                });
            });
        }
    }
}
