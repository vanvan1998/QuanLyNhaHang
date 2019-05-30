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
    /// Interaction logic for MonthStatisticalUserControl.xaml
    /// </summary>
    public partial class WeekStatisticalUserControl : UserControl
    {

        public WeekStatisticalUserControl()
        {
            InitializeComponent();

            //DateTime day6 = DateTime.Today.AddDays(-6);
            //DateTime day5 = DateTime.Today.AddDays(-5);
            //DateTime day4 = DateTime.Today.AddDays(-4);
            //DateTime day3 = DateTime.Today.AddDays(-3);
            //DateTime day2 = DateTime.Today.AddDays(-2);
            //DateTime day1 = DateTime.Today.AddDays(-1);
            //DateTime today = DateTime.Today;
            //DateTime midNight = DateTime.Today.AddDays(1).AddSeconds(-1);

            //decimal sv0 = 0;
            //decimal sv1 = 0;
            //decimal sv2 = 0;
            //decimal sv3 = 0;
            //decimal sv4 = 0;
            //decimal sv5 = 0;
            //decimal sv6 = 0;

            //decimal vv0 = 0;
            //decimal vv1 = 0;
            //decimal vv2 = 0;
            //decimal vv3 = 0;
            //decimal vv4 = 0;
            //decimal vv5 = 0;
            //decimal vv6 = 0;

            //TotalRevenue.Text = "0";

            //if (DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < midNight).Count() != 0)
            //{
            //    TotalRevenue.Text = Math.Round(DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < midNight).Sum(x => x.tongTien), 0).ToString();
            //}

            //IQueryable<HoaDon> phongTieuChuan = DataProvider.Ins.DB.HoaDons.Where(x => x.Phong.maPhong.Contains("SS") || x.Phong.maPhong.Contains("SC") || x.Phong.maPhong.Contains("SG"));

            //if (phongTieuChuan.Count() > 0)
            //{
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > today && x.thoiGianLap < midNight).Count() != 0)
            //    {
            //        sv0 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > today && x.thoiGianLap < midNight).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > day1 && x.thoiGianLap < today).Count() != 0)
            //    {
            //        sv1 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > day1 && x.thoiGianLap < today).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > day2 && x.thoiGianLap < day1).Count() != 0)
            //    {
            //        sv2 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > day2 && x.thoiGianLap < day1).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > day3 && x.thoiGianLap < day2).Count() != 0)
            //    {
            //        sv3 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > day3 && x.thoiGianLap < day2).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > day4 && x.thoiGianLap < day3).Count() != 0)
            //    {
            //        sv4 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > day4 && x.thoiGianLap < day3).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > day5 && x.thoiGianLap < day4).Count() != 0)
            //    {
            //        sv5 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > day5 && x.thoiGianLap < day4).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongTieuChuan.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < day5).Count() != 0)
            //    {
            //        sv6 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < day5).Sum(x => x.tongTien), 0);
            //    }
            //}

            //IQueryable<HoaDon> phongVIP = DataProvider.Ins.DB.HoaDons.Where(x => x.Phong.maPhong.Contains("VS") || x.Phong.maPhong.Contains("VC") || x.Phong.maPhong.Contains("VG"));

            //if (phongVIP.Count() > 0)
            //{
            //    if (phongVIP.Where(x => x.thoiGianLap > today && x.thoiGianLap < midNight).Count() != 0)
            //    {
            //        vv0 = Math.Round(phongVIP.Where(x => x.thoiGianLap > today && x.thoiGianLap < midNight).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongVIP.Where(x => x.thoiGianLap > day1 && x.thoiGianLap < today).Count() != 0)
            //    {
            //        vv1 = Math.Round(phongVIP.Where(x => x.thoiGianLap > day1 && x.thoiGianLap < today).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongVIP.Where(x => x.thoiGianLap > day2 && x.thoiGianLap < day1).Count() != 0)
            //    {
            //        vv2 = Math.Round(phongVIP.Where(x => x.thoiGianLap > day2 && x.thoiGianLap < day1).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongVIP.Where(x => x.thoiGianLap > day3 && x.thoiGianLap < day2).Count() != 0)
            //    {
            //        vv3 = Math.Round(phongVIP.Where(x => x.thoiGianLap > day3 && x.thoiGianLap < day2).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongVIP.Where(x => x.thoiGianLap > day4 && x.thoiGianLap < day3).Count() != 0)
            //    {
            //        vv4 = Math.Round(phongVIP.Where(x => x.thoiGianLap > day4 && x.thoiGianLap < day3).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongVIP.Where(x => x.thoiGianLap > day5 && x.thoiGianLap < day4).Count() != 0)
            //    {
            //        vv5 = Math.Round(phongVIP.Where(x => x.thoiGianLap > day5 && x.thoiGianLap < day4).Sum(x => x.tongTien), 0);
            //    }
            //    if (phongVIP.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < day5).Count() != 0)
            //    {
            //        vv6 = Math.Round(phongVIP.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < day5).Sum(x => x.tongTien), 0);
            //    }
            //}

            //IQueryable<HoaDon> hoaDon7NgayGanDay = DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > day6 && x.thoiGianLap < midNight);

            //List<int> soLuongHoaDonMoiLoaiPhong = new List<int>();
            //soLuongHoaDonMoiLoaiPhong.Add(hoaDon7NgayGanDay.Where(x => x.Phong.loaiPhong == "Tiêu chuẩn - Đơn").Count());
            //soLuongHoaDonMoiLoaiPhong.Add(hoaDon7NgayGanDay.Where(x => x.Phong.loaiPhong == "Tiêu chuẩn - Đôi").Count());
            //soLuongHoaDonMoiLoaiPhong.Add(hoaDon7NgayGanDay.Where(x => x.Phong.loaiPhong == "Tiêu chuẩn - Nhóm").Count());
            //soLuongHoaDonMoiLoaiPhong.Add(hoaDon7NgayGanDay.Where(x => x.Phong.loaiPhong == "VIP - Đơn").Count());
            //soLuongHoaDonMoiLoaiPhong.Add(hoaDon7NgayGanDay.Where(x => x.Phong.loaiPhong == "VIP - Đôi").Count());
            //soLuongHoaDonMoiLoaiPhong.Add(hoaDon7NgayGanDay.Where(x => x.Phong.loaiPhong == "VIP - Nhóm").Count());

            //List<string> loaiPhong = new List<string>();
            //loaiPhong.Add("Tiêu chuẩn - Đơn");
            //loaiPhong.Add("Tiêu chuẩn - Đôi");
            //loaiPhong.Add("Tiêu chuẩn - Nhóm");
            //loaiPhong.Add("VIP - Đơn");
            //loaiPhong.Add("VIP - Đôi");
            //loaiPhong.Add("VIP - Nhóm");

            //BestSale.Text = loaiPhong[soLuongHoaDonMoiLoaiPhong.IndexOf(soLuongHoaDonMoiLoaiPhong.Max())];
            //BadSale.Text = loaiPhong[soLuongHoaDonMoiLoaiPhong.IndexOf(soLuongHoaDonMoiLoaiPhong.Min())];

            //SeriesCollection = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Title = "Phòng Tiêu chuẩn",
            //        Values = new ChartValues<decimal> {sv6,sv5,sv4,sv3,sv2,sv1,sv0}
            //    },
            //    new LineSeries
            //    {
            //        Title = "Phòng VIP",
            //        Values = new ChartValues<decimal> {vv6,vv5,vv4,vv3,vv2,vv1,vv0}
            //    }
            //};

            //Labels = new[] {
            //    DateTime.Today.AddDays(-6).DayOfWeek.ToString(),
            //    DateTime.Today.AddDays(-5).DayOfWeek.ToString(),
            //    DateTime.Today.AddDays(-4).DayOfWeek.ToString(),
            //    DateTime.Today.AddDays(-3).DayOfWeek.ToString(),
            //    DateTime.Today.AddDays(-2).DayOfWeek.ToString(),
            //    DateTime.Today.AddDays(-1).DayOfWeek.ToString(),
            //    DateTime.Today.DayOfWeek.ToString(),
            //};

            //YFormatter = value => value.ToString("C");

            //DataContext = this;
        }

        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> YFormatter { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 80;
        }
    }
}
