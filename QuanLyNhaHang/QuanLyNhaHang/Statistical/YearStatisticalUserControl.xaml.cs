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
using Newtonsoft.Json;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang.Statistical
{
    /// <summary>
    /// Interaction logic for YearStatisticalUserControl.xaml
    /// </summary>
    public partial class YearStatisticalUserControl : UserControl
    {
        ObservableCollection<Model.Bill> ListBill = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw3 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw1 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw2 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw4 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw5 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw6 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw7 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw8 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw9 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw10 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw11 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw12 = new ObservableCollection<Model.Bill>();
        int totalw1 = 0, totalw2 = 0, totalw3 = 0, totalw4 = 0, totalw5 = 0, totalw6 = 0,
            totalw7 = 0, totalw8 = 0, totalw9 = 0, totalw10 = 0, totalw11 = 0, totalw12 = 0;

        public YearStatisticalUserControl()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            DateTime first = new DateTime(now.Year, 1, 1);
            DateTime month1 = first.AddMonths(1);
            DateTime month2 = first.AddMonths(2);
            DateTime month3 = first.AddMonths(3);
            DateTime month4 = first.AddMonths(4);
            DateTime month5 = first.AddMonths(5);
            DateTime month6 = first.AddMonths(6);
            DateTime month7 = first.AddMonths(7);
            DateTime month8 = first.AddMonths(8);
            DateTime month9 = first.AddMonths(9);
            DateTime month10 = first.AddMonths(10);
            DateTime month11 = first.AddMonths(11);
            DateTime month12 = first.AddMonths(12);
            DateTime end = new DateTime(now.Year + 1, 1, 1);

            decimal vv1 = 0;
            decimal vv2 = 0;
            decimal vv3 = 0;
            decimal vv4 = 0;
            decimal vv5 = 0;
            decimal vv6 = 0;
            decimal vv7 = 0;
            decimal vv8 = 0;
            decimal vv9 = 0;
            decimal vv10 = 0;
            decimal vv11 = 0;
            decimal vv12 = 0;

            TotalRevenue.Text = "0";

            string startTime = first.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string endTime = end.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week1Time = month1.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week2Time = month2.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week3Time = month3.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week4Time = month4.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week5Time = month5.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week6Time = month6.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week7Time = month7.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week8Time = month8.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week9Time = month9.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week10Time = month10.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week11Time = month11.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));

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
                string result4 = API.Filter(week3Time.Substring(0, 10), week4Time.Substring(0, 10));
                totalw4 = Load(result4, ListBillw4);
                if (ListBillw4.Count != 0)
                {
                    vv4 = totalw4;
                }
                string result5 = API.Filter(week4Time.Substring(0, 10), week5Time.Substring(0, 10));
                totalw5 = Load(result5, ListBillw5);
                if (ListBillw5.Count != 0)
                {
                    vv5 = totalw5;
                }
                string result6 = API.Filter(week5Time.Substring(0, 10), week6Time.Substring(0, 10));
                totalw6 = Load(result6, ListBillw6);
                if (ListBillw6.Count != 0)
                {
                    vv6 = totalw6;
                }
                string result7 = API.Filter(week6Time.Substring(0, 10), week7Time.Substring(0, 10));
                totalw7 = Load(result7, ListBillw7);
                if (ListBillw7.Count != 0)
                {
                    vv7 = totalw7;
                }
                string result8 = API.Filter(week7Time.Substring(0, 10), week8Time.Substring(0, 10));
                totalw8 = Load(result8, ListBillw8);
                if (ListBillw8.Count != 0)
                {
                    vv8 = totalw8;
                }
                string result9 = API.Filter(week8Time.Substring(0, 10), week9Time.Substring(0, 10));
                totalw9 = Load(result9, ListBillw9);
                if (ListBillw9.Count != 0)
                {
                    vv9 = totalw9;
                }
                string result10 = API.Filter(week9Time.Substring(0, 10), week10Time.Substring(0, 10));
                totalw10 = Load(result10, ListBillw10);
                if (ListBillw10.Count != 0)
                {
                    vv10 = totalw10;
                }
                string result11 = API.Filter(week10Time.Substring(0, 10), week11Time.Substring(0, 10));
                totalw11 = Load(result11, ListBillw11);
                if (ListBillw11.Count != 0)
                {
                    vv11 = totalw11;
                }
                string result12 = API.Filter(week11Time.Substring(0, 10), endTime.Substring(0, 10));
                totalw12 = Load(result12, ListBillw12);
                if (ListBillw12.Count != 0)
                {
                    vv12 = totalw12;
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
                    Values = new ChartValues<decimal> {vv1,vv2,vv3,vv4,vv5,vv6,vv7,vv8,vv9,vv10,vv11,vv12}
                }
            };

            Labels = new[] {
                "Tháng " + first.Month.ToString(),
                "Tháng " + month1.Month.ToString(),
                "Tháng " + month2.Month.ToString(),
                "Tháng " + month3.Month.ToString(),
                "Tháng " + month4.Month.ToString(),
                "Tháng " + month5.Month.ToString(),
                "Tháng " + month6.Month.ToString(),
                "Tháng " + month7.Month.ToString(),
                "Tháng " + month8.Month.ToString(),
                "Tháng " + month9.Month.ToString(),
                "Tháng " + month10.Month.ToString(),
                "Tháng " + month11.Month.ToString(),
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
