using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
//using HotelManagementApp.Entity;
using System.Collections.Generic;
using QuanLyNhaHang.Model;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace QuanLyNhaHang.Statistical
{
    /// <summary>
    /// Interaction logic for MonthStatisticalUserControl.xaml
    /// </summary>
    public partial class MonthStatisticalUserControl : UserControl
    {
        ObservableCollection<Model.Bill> ListBill = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw3 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw1 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw2 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw4 = new ObservableCollection<Model.Bill>();
        int totalw1 = 0, totalw2 = 0, totalw3 = 0, totalw4 = 0;

        public MonthStatisticalUserControl()
        {
            InitializeComponent();


            DateTime now = DateTime.Now;

            DateTime first = new DateTime(now.Year, now.Month, 1);
            DateTime week1 = new DateTime(now.Year, now.Month, 8);
            DateTime week2 = new DateTime(now.Year, now.Month, 15);
            DateTime week3 = new DateTime(now.Year, now.Month, 22);
            DateTime end = first.AddDays(29);

            decimal vv1 = 0;
            decimal vv2 = 0;
            decimal vv3 = 0;
            decimal vv4 = 0;

            string startTime = first.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string endTime = end.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week1Time = week1.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week2Time = week2.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week3Time = week3.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));


            string result = API.Filter(startTime.Substring(0, 10), endTime.Substring(0, 10));
            dynamic stuff = JsonConvert.DeserializeObject(result);

            int total = 0;


            foreach (var item in stuff)
            {
                Boolean test = false;
                if (ListBill.Count != 0)
                {
                    foreach (var bill in ListBill)
                    {
                        int tablenumber = item.tableNumber;
                        if (bill.tableNumber == tablenumber)
                        {
                            bill.count++;
                            test = true;
                        }
                    }
                }
                if (test == false)
                {
                    ListBill.Add(new Model.Bill()
                    {
                        total = item.total,
                        tableNumber = item.tableNumber,
                        time = item.createdAt,
                        count = 1,
                    });
                }
                int temp = item.total;
                total = temp + total;
            };

            TotalRevenue.Text = total.ToString();

            if (ListBill.Count() > 0)
            {
                string result1 = API.Filter(startTime.Substring(0, 10), week1Time.Substring(0, 10));
                totalw1 = Load(result1, ListBillw1);
                if (ListBillw1.Count != 0)
                {
                    vv1 = totalw1;
                }
                string result2 = API.Filter(week1Time.Substring(0, 10), week2Time.Substring(0, 10));
                totalw2 = Load(result2, ListBillw2);
                if (ListBillw2.Count != 0)
                {
                    vv2 = totalw2;
                }
                string result3 = API.Filter(week2Time.Substring(0, 10), week3Time.Substring(0, 10));
                totalw3 = Load(result3, ListBillw3);
                if (ListBillw3.Count != 0)
                {
                    vv3 = totalw3;
                }
                string result4 = API.Filter(week3Time.Substring(0, 10), endTime.Substring(0, 10));
                totalw4 = Load(result4, ListBillw4);
                if (ListBillw4.Count != 0)
                {
                    vv4 = totalw4;
                }
            }

            Bill bestbill = ListBill[0];
            Bill badbill = ListBill[0];

            foreach (var item in ListBill)
            {
                if (item.count > bestbill.count)
                {
                    bestbill = item;
                }
                if (item.count < badbill.count)
                {
                    badbill = item;
                }
            }
            BestSale.Text = "Bàn số " + bestbill.tableNumber.ToString();
            BadSale.Text = "Bàn số " + badbill.tableNumber.ToString();

            SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Doanh thu",
                        Values = new ChartValues<decimal> {vv1,vv2,vv3,vv4}
                    }
                };

            Labels = new[] {
                    "Tuần 1",
                    "Tuần 2",
                    "Tuần 3",
                    "Tuần 4",
                };

            YFormatter = value => value.ToString("C");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 80;
        }


        private int Load(string result, ObservableCollection<Model.Bill> ListBill)
        {
            int total = 0;
            dynamic stuff = JsonConvert.DeserializeObject(result);
            foreach (var item in stuff)
            {
                ListBill.Add(new Model.Bill()
                {
                    total = item.total,
                    tableNumber = item.tableNumber,
                    time = item.createdAt,
                });
                int temp = item.total;
                total = total + temp;
            };
            return total;
        }
    }


}
