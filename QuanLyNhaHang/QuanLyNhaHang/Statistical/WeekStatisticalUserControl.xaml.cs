using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
//using HotelManagementApp.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using QuanLyNhaHang.Model;
using Newtonsoft.Json;

namespace QuanLyNhaHang.Statistical
{
    /// <summary>
    /// Interaction logic for MonthStatisticalUserControl.xaml
    /// </summary>
    public partial class WeekStatisticalUserControl : UserControl
    {
        ObservableCollection<Model.Bill> ListBill = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw3 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw1 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw2 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw4 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw5 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw6 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw7 = new ObservableCollection<Model.Bill>();
        int totalw1 = 0, totalw2 = 0, totalw3 = 0, totalw4 = 0, totalw5 = 0, totalw6 = 0, totalw7 = 0;

        public WeekStatisticalUserControl()
        {
            InitializeComponent();

            DateTime day6 = DateTime.Today.AddDays(-6);
            DateTime day5 = DateTime.Today.AddDays(-5);
            DateTime day4 = DateTime.Today.AddDays(-4);
            DateTime day3 = DateTime.Today.AddDays(-3);
            DateTime day2 = DateTime.Today.AddDays(-2);
            DateTime day1 = DateTime.Today.AddDays(-1);
            DateTime today = DateTime.Today;
            DateTime midNight = DateTime.Today.AddDays(1).AddSeconds(-1);


            decimal vv1 = 0;
            decimal vv2 = 0;
            decimal vv3 = 0;
            decimal vv4 = 0;
            decimal vv5 = 0;
            decimal vv6 = 0;
            decimal vv7 = 0;

            TotalRevenue.Text = "0";

            string startTime = today.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string endTime = midNight.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week1Time = day1.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week2Time = day2.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week3Time = day3.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week4Time = day4.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week5Time = day5.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week6Time = day6.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));


            string result = API.Filter(week6Time.Substring(0, 10), endTime.Substring(0, 10));
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
                string result1 = API.Filter(startTime.Substring(0, 10), startTime.Substring(0, 10));
                totalw1 = Load(result1, ListBillw1);
                if (ListBillw1.Count != 0)
                {
                    vv1 = totalw1;
                }
                string result2 = API.Filter(week1Time.Substring(0, 10), week1Time.Substring(0, 10));
                totalw2 = Load(result2, ListBillw2);
                if (ListBillw2.Count != 0)
                {
                    vv2 = totalw2;
                }
                string result3 = API.Filter(week2Time.Substring(0, 10), week2Time.Substring(0, 10));
                totalw3 = Load(result3, ListBillw3);
                if (ListBillw3.Count != 0)
                {
                    vv3 = totalw3;
                }
                string result4 = API.Filter(week3Time.Substring(0, 10), week3Time.Substring(0, 10));
                totalw4 = Load(result4, ListBillw4);
                if (ListBillw4.Count != 0)
                {
                    vv4 = totalw4;
                }
                string result5 = API.Filter(week4Time.Substring(0, 10), week4Time.Substring(0, 10));
                totalw5 = Load(result5, ListBillw5);
                if (ListBillw5.Count != 0)
                {
                    vv5 = totalw5;
                }
                string result6 = API.Filter(week5Time.Substring(0, 10), week5Time.Substring(0, 10));
                totalw6 = Load(result6, ListBillw6);
                if (ListBillw6.Count != 0)
                {
                    vv6 = totalw6;
                }
                string result7 = API.Filter(week6Time.Substring(0, 10), week6Time.Substring(0, 10));
                totalw7 = Load(result7, ListBillw7);
                if (ListBillw7.Count != 0)
                {
                    vv7 = totalw7;
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
                    Values = new ChartValues<decimal> {vv7,vv6,vv5,vv4,vv3,vv2,vv1}
                }
            };

            Labels = new[] {
                DateTime.Today.AddDays(-6).DayOfWeek.ToString(),
                DateTime.Today.AddDays(-5).DayOfWeek.ToString(),
                DateTime.Today.AddDays(-4).DayOfWeek.ToString(),
                DateTime.Today.AddDays(-3).DayOfWeek.ToString(),
                DateTime.Today.AddDays(-2).DayOfWeek.ToString(),
                DateTime.Today.AddDays(-1).DayOfWeek.ToString(),
                DateTime.Today.DayOfWeek.ToString(),
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
