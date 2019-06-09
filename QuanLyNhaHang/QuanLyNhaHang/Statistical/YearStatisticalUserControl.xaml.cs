using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
//using HotelManagementApp.Entity;
using System.Collections.Generic;

namespace QuanLyNhaHang.Statistical
{
    /// <summary>
    /// Interaction logic for YearStatisticalUserControl.xaml
    /// </summary>
    public partial class YearStatisticalUserControl : UserControl
    {

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

            decimal sv1 = 0;
            decimal sv2 = 0;
            decimal sv3 = 0;
            decimal sv4 = 0;
            decimal sv5 = 0;
            decimal sv6 = 0;
            decimal sv7 = 0;
            decimal sv8 = 0;
            decimal sv9 = 0;
            decimal sv10 = 0;
            decimal sv11 = 0;
            decimal sv12 = 0;

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

            //if (DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end).Count() != 0)
            //{
            //    TotalRevenue.Text = Math.Round(DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end).Sum(x => x.tongTien), 0).ToString();
            //}

            //IQueryable<HoaDon> banTieuChuan = DataProvider.Ins.DB.HoaDons.Where(x => x.Ban.maBan.Contains("SS") || x.Ban.maBan.Contains("SC") || x.Ban.maBan.Contains("SG"));

            //if (banTieuChuan.Count() > 0)
            //{
            //    if (banTieuChuan.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Count() != 0)
            //    {
            //        sv1 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Count() != 0)
            //    {
            //        sv2 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Count() != 0)
            //    {
            //        sv3 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month3 && x.thoiGianLap < month4).Count() != 0)
            //    {
            //        sv4 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month3 && x.thoiGianLap < month4).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month4 && x.thoiGianLap < month5).Count() != 0)
            //    {
            //        sv5 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month4 && x.thoiGianLap < month5).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month5 && x.thoiGianLap < month6).Count() != 0)
            //    {
            //        sv6 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month5 && x.thoiGianLap < month6).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month6 && x.thoiGianLap < month7).Count() != 0)
            //    {
            //        sv7 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month6 && x.thoiGianLap < month7).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month7 && x.thoiGianLap < month8).Count() != 0)
            //    {
            //        sv8 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month7 && x.thoiGianLap < month8).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month8 && x.thoiGianLap < month9).Count() != 0)
            //    {
            //        sv9 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month8 && x.thoiGianLap < month9).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month9 && x.thoiGianLap < month10).Count() != 0)
            //    {
            //        sv10 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month9 && x.thoiGianLap < month10).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month10 && x.thoiGianLap < month11).Count() != 0)
            //    {
            //        sv11 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month10 && x.thoiGianLap < month11).Sum(x => x.tongTien), 0);
            //    }
            //    if (banTieuChuan.Where(x => x.thoiGianLap > month12 && x.thoiGianLap < end).Count() != 0)
            //    {
            //        sv12 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month12 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //    }
            //}

            //IQueryable<HoaDon> banVIP = DataProvider.Ins.DB.HoaDons.Where(x => x.Ban.maBan.Contains("VS") || x.Ban.maBan.Contains("VC") || x.Ban.maBan.Contains("VG"));

            //if (banVIP.Count() > 0)
            //{
            //    if (banVIP.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Count() != 0)
            //    {
            //        vv1 = Math.Round(banVIP.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Count() != 0)
            //    {
            //        vv2 = Math.Round(banVIP.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Count() != 0)
            //    {
            //        vv3 = Math.Round(banVIP.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month3 && x.thoiGianLap < month4).Count() != 0)
            //    {
            //        vv4 = Math.Round(banVIP.Where(x => x.thoiGianLap > month3 && x.thoiGianLap < month4).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month4 && x.thoiGianLap < month5).Count() != 0)
            //    {
            //        vv5 = Math.Round(banVIP.Where(x => x.thoiGianLap > month4 && x.thoiGianLap < month5).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month5 && x.thoiGianLap < month6).Count() != 0)
            //    {
            //        vv6 = Math.Round(banVIP.Where(x => x.thoiGianLap > month5 && x.thoiGianLap < month6).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month6 && x.thoiGianLap < month7).Count() != 0)
            //    {
            //        vv7 = Math.Round(banVIP.Where(x => x.thoiGianLap > month6 && x.thoiGianLap < month7).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month7 && x.thoiGianLap < month8).Count() != 0)
            //    {
            //        vv8 = Math.Round(banVIP.Where(x => x.thoiGianLap > month7 && x.thoiGianLap < month8).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month8 && x.thoiGianLap < month9).Count() != 0)
            //    {
            //        vv9 = Math.Round(banVIP.Where(x => x.thoiGianLap > month8 && x.thoiGianLap < month9).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month9 && x.thoiGianLap < month10).Count() != 0)
            //    {
            //        vv10 = Math.Round(banVIP.Where(x => x.thoiGianLap > month9 && x.thoiGianLap < month10).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month10 && x.thoiGianLap < month11).Count() != 0)
            //    {
            //        vv11 = Math.Round(banVIP.Where(x => x.thoiGianLap > month10 && x.thoiGianLap < month11).Sum(x => x.tongTien), 0);
            //    }
            //    if (banVIP.Where(x => x.thoiGianLap > month12 && x.thoiGianLap < end).Count() != 0)
            //    {
            //        vv12 = Math.Round(banVIP.Where(x => x.thoiGianLap > month12 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //    }
            //}

            //IQueryable<HoaDon> hoaDonThangNay = DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end);

            //List<int> soLuongHoaDonMoiLoaiBan = new List<int>();
            //soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "Tiêu chuẩn - 4 người").Count());
            //soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "Tiêu chuẩn - 8 người").Count());
            //soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "Tiêu chuẩn - 12 người").Count());
            //soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "VIP - 4 người").Count());
            //soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "VIP - 8 người").Count());
            //soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "VIP - 12 người").Count());

            //List<string> loaiBan = new List<string>();
            //loaiBan.Add("Tiêu chuẩn - 4 người");
            //loaiBan.Add("Tiêu chuẩn - 8 người");
            //loaiBan.Add("Tiêu chuẩn - 12 người");
            //loaiBan.Add("VIP - 4 người");
            //loaiBan.Add("VIP - 8 người");
            //loaiBan.Add("VIP - 12 người");

            //BestSale.Text = loaiBan[soLuongHoaDonMoiLoaiBan.IndexOf(soLuongHoaDonMoiLoaiBan.Max())];
            //BadSale.Text = loaiBan[soLuongHoaDonMoiLoaiBan.IndexOf(soLuongHoaDonMoiLoaiBan.Min())];

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Phòng Tiêu chuẩn",
                    Values = new ChartValues<decimal> {sv1,sv2,sv3,sv4,sv5,sv6,sv7,sv8,sv9,sv10,sv11,sv12}
                },
                new LineSeries
                {
                    Title = "Phòng VIP",
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
    }
}
