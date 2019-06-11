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
    /// Interaction logic for QuarterStatisticalUserControl.xaml
    /// </summary>
    public partial class QuarterStatisticalUserControl : UserControl
    {
        ObservableCollection<Model.Bill> ListBill = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw3 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw1 = new ObservableCollection<Model.Bill>();
        ObservableCollection<Model.Bill> ListBillw2 = new ObservableCollection<Model.Bill>();
        int totalw1 = 0, totalw2 = 0, totalw3 = 0;

        public QuarterStatisticalUserControl()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            int q = (DateTime.Now.Month + 2) / 3;
            DateTime first = new DateTime(now.Year, q * 3 - 2, 1);
            DateTime month1 = first.AddMonths(1);
            DateTime month2 = first.AddMonths(2);
            DateTime end = first.AddMonths(3);

            decimal sv1 = 0;
            decimal sv2 = 0;
            decimal sv3 = 0;

            decimal vv1 = 0;
            decimal vv2 = 0;
            decimal vv3 = 0;

            string startTime = first.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string endTime = end.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week1Time = month1.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));
            string week2Time = month2.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));

            TotalRevenue.Text = "0";

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
                string result3 = API.Filter(week2Time.Substring(0, 10), endTime.Substring(0, 10));
                totalw3 = Load(result3, ListBillw3);
                if (ListBillw3.Count != 0)
                {
                    vv3 = totalw3;
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
                        Values = new ChartValues<decimal> {vv1,vv2,vv3}
                    }
                };

            Labels = new[] {
                    "Tháng " + first.Month.ToString(),
                    "Tháng " + month1.Month.ToString(),
                    "Tháng " + month2.Month.ToString(),
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
