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
    /// Interaction logic for QuarterStatisticalUserControl.xaml
    /// </summary>
    public partial class QuarterStatisticalUserControl : UserControl
    {

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

            TotalRevenue.Text = "0";

            //    if (DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end).Count() != 0)
            //    {
            //        TotalRevenue.Text = Math.Round(DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end).Sum(x => x.tongTien), 0).ToString();
            //    }

            //    IQueryable<HoaDon> banTieuChuan = DataProvider.Ins.DB.HoaDons.Where(x => x.Ban.maBan.Contains("SS") || x.Ban.maBan.Contains("SC") || x.Ban.maBan.Contains("SG"));

            //    if (banTieuChuan.Count() > 0)
            //    {

            //        if (banTieuChuan.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Count() != 0)
            //        {
            //            sv1 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Sum(x => x.tongTien), 0);
            //        }
            //        if (banTieuChuan.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Count() != 0)
            //        {
            //            sv2 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Sum(x => x.tongTien), 0);
            //        }
            //        if (banTieuChuan.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Count() != 0)
            //        {
            //            sv3 = Math.Round(banTieuChuan.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //        }
            //    }

            //    IQueryable<HoaDon> banVIP = DataProvider.Ins.DB.HoaDons.Where(x => x.Ban.maBan.Contains("VS") || x.Ban.maBan.Contains("VC") || x.Ban.maBan.Contains("VG"));

            //    if (banVIP.Count() > 0)
            //    {
            //        if (banVIP.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Count() != 0)
            //        {
            //            vv1 = Math.Round(banVIP.Where(x => x.thoiGianLap > first && x.thoiGianLap < month1).Sum(x => x.tongTien), 0);
            //        }
            //        if (banVIP.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Count() != 0)
            //        {
            //            vv2 = Math.Round(banVIP.Where(x => x.thoiGianLap > month1 && x.thoiGianLap < month2).Sum(x => x.tongTien), 0);
            //        }
            //        if (banVIP.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Count() != 0)
            //        {
            //            vv3 = Math.Round(banVIP.Where(x => x.thoiGianLap > month2 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //        }
            //    }

            //    IQueryable<HoaDon> hoaDonThangNay = DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end);

            //    List<int> soLuongHoaDonMoiLoaiBan = new List<int>();
            //    soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "Tiêu chuẩn - 4 người").Count());
            //    soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "Tiêu chuẩn - 8 người").Count());
            //    soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "Tiêu chuẩn - 12 người").Count());
            //    soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "VIP - 4 người").Count());
            //    soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "VIP - 8 người").Count());
            //    soLuongHoaDonMoiLoaiBan.Add(hoaDonThangNay.Where(x => x.Ban.loaiBan == "VIP - 12 người").Count());

            //    List<string> loaiBan = new List<string>();
            //    loaiBan.Add("Tiêu chuẩn - 4 người");
            //    loaiBan.Add("Tiêu chuẩn - 8 người");
            //    loaiBan.Add("Tiêu chuẩn - 12 người");
            //    loaiBan.Add("VIP - 4 người");
            //    loaiBan.Add("VIP - 8 người");
            //    loaiBan.Add("VIP - 12 người");

            //    BestSale.Text = loaiBan[soLuongHoaDonMoiLoaiBan.IndexOf(soLuongHoaDonMoiLoaiBan.Max())];
            //    BadSale.Text = loaiBan[soLuongHoaDonMoiLoaiBan.IndexOf(soLuongHoaDonMoiLoaiBan.Min())];

            SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Phòng Tiêu chuẩn",
                        Values = new ChartValues<decimal> {sv1,sv2,sv3}
                    },
                    new LineSeries
                    {
                        Title = "Phòng VIP",
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
    }
}
