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
    public partial class MonthStatisticalUserControl : UserControl
    {

        public MonthStatisticalUserControl()
        {
            InitializeComponent();

            //    DateTime now = DateTime.Now;
            //    DateTime first = new DateTime(now.Year, now.Month, 1);
            //    DateTime week1 = new DateTime(now.Year, now.Month, 8);
            //    DateTime week2 = new DateTime(now.Year, now.Month, 15);
            //    DateTime week3 = new DateTime(now.Year, now.Month, 22);
            //    DateTime end = first.AddDays(29);

            //    decimal sv1 = 0;
            //    decimal sv2 = 0;
            //    decimal sv3 = 0;
            //    decimal sv4 = 0;

            //    decimal vv1 = 0;
            //    decimal vv2 = 0;
            //    decimal vv3 = 0;
            //    decimal vv4 = 0;

            //    TotalRevenue.Text = "0";

            //    if (DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end).Count() != 0)
            //    {
            //        TotalRevenue.Text = Math.Round(DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end).Sum(x => x.tongTien), 0).ToString();
            //    }

            //    IQueryable<HoaDon> phongTieuChuan = DataProvider.Ins.DB.HoaDons.Where(x => x.Phong.maPhong.Contains("SS") || x.Phong.maPhong.Contains("SC") || x.Phong.maPhong.Contains("SG"));

            //    if (phongTieuChuan.Count() > 0)
            //    {

            //        if (phongTieuChuan.Where(x => x.thoiGianLap > first && x.thoiGianLap < week1).Count() != 0)
            //        {
            //            sv1 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > first && x.thoiGianLap < week1).Sum(x => x.tongTien), 0);
            //        }
            //        if (phongTieuChuan.Where(x => x.thoiGianLap > week1 && x.thoiGianLap < week2).Count() != 0)
            //        {
            //            sv2 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > week1 && x.thoiGianLap < week2).Sum(x => x.tongTien), 0);
            //        }
            //        if (phongTieuChuan.Where(x => x.thoiGianLap > week2 && x.thoiGianLap < week3).Count() != 0)
            //        {
            //            sv3 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > week2 && x.thoiGianLap < week3).Sum(x => x.tongTien), 0);
            //        }
            //        if (phongTieuChuan.Where(x => x.thoiGianLap > week3 && x.thoiGianLap < end).Count() != 0)
            //        {
            //            sv4 = Math.Round(phongTieuChuan.Where(x => x.thoiGianLap > week3 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //        }
            //    }

            //    IQueryable<HoaDon> phongVIP = DataProvider.Ins.DB.HoaDons.Where(x => x.Phong.maPhong.Contains("VS") || x.Phong.maPhong.Contains("VC") || x.Phong.maPhong.Contains("VG"));

            //    if (phongVIP.Count() > 0)
            //    {
            //        if (phongVIP.Where(x => x.thoiGianLap > first && x.thoiGianLap < week1).Count() != 0)
            //        {
            //            vv1 = Math.Round(phongVIP.Where(x => x.thoiGianLap > first && x.thoiGianLap < week1).Sum(x => x.tongTien), 0);
            //        }
            //        if (phongVIP.Where(x => x.thoiGianLap > week1 && x.thoiGianLap < week2).Count() != 0)
            //        {
            //            vv2 = Math.Round(phongVIP.Where(x => x.thoiGianLap > week1 && x.thoiGianLap < week2).Sum(x => x.tongTien), 0);
            //        }
            //        if (phongVIP.Where(x => x.thoiGianLap > week2 && x.thoiGianLap < week3).Count() != 0)
            //        {
            //            vv3 = Math.Round(phongVIP.Where(x => x.thoiGianLap > week2 && x.thoiGianLap < week3).Sum(x => x.tongTien), 0);
            //        }
            //        if (phongVIP.Where(x => x.thoiGianLap > week3 && x.thoiGianLap < end).Count() != 0)
            //        {
            //            vv4 = Math.Round(phongVIP.Where(x => x.thoiGianLap > week3 && x.thoiGianLap < end).Sum(x => x.tongTien), 0);
            //        }
            //    }

            //    IQueryable<HoaDon> hoaDonThangNay = DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > first && x.thoiGianLap < end);

            //    List<int> soLuongHoaDonMoiLoaiPhong = new List<int>();
            //    soLuongHoaDonMoiLoaiPhong.Add(hoaDonThangNay.Where(x => x.Phong.loaiPhong == "Tiêu chuẩn - Đơn").Count());
            //    soLuongHoaDonMoiLoaiPhong.Add(hoaDonThangNay.Where(x => x.Phong.loaiPhong == "Tiêu chuẩn - Đôi").Count());
            //    soLuongHoaDonMoiLoaiPhong.Add(hoaDonThangNay.Where(x => x.Phong.loaiPhong == "Tiêu chuẩn - Nhóm").Count());
            //    soLuongHoaDonMoiLoaiPhong.Add(hoaDonThangNay.Where(x => x.Phong.loaiPhong == "VIP - Đơn").Count());
            //    soLuongHoaDonMoiLoaiPhong.Add(hoaDonThangNay.Where(x => x.Phong.loaiPhong == "VIP - Đôi").Count());
            //    soLuongHoaDonMoiLoaiPhong.Add(hoaDonThangNay.Where(x => x.Phong.loaiPhong == "VIP - Nhóm").Count());

            //    List<string> loaiPhong = new List<string>();
            //    loaiPhong.Add("Tiêu chuẩn - Đơn");
            //    loaiPhong.Add("Tiêu chuẩn - Đôi");
            //    loaiPhong.Add("Tiêu chuẩn - Nhóm");
            //    loaiPhong.Add("VIP - Đơn");
            //    loaiPhong.Add("VIP - Đôi");
            //    loaiPhong.Add("VIP - Nhóm");

            //    BestSale.Text = loaiPhong[soLuongHoaDonMoiLoaiPhong.IndexOf(soLuongHoaDonMoiLoaiPhong.Max())];
            //    BadSale.Text = loaiPhong[soLuongHoaDonMoiLoaiPhong.IndexOf(soLuongHoaDonMoiLoaiPhong.Min())];

            //    SeriesCollection = new SeriesCollection
            //    {
            //        new LineSeries
            //        {
            //            Title = "Phòng Tiêu chuẩn",
            //            Values = new ChartValues<decimal> {sv1,sv2,sv3,sv4}
            //        },
            //        new LineSeries
            //        {
            //            Title = "Phòng VIP",
            //            Values = new ChartValues<decimal> {vv1,vv2,vv3,vv4}
            //        }
            //    };

            //    Labels = new[] {
            //        "Tuần 1",
            //        "Tuần 2",
            //        "Tuần 3",
            //        "Tuần 4",
            //    };

            //    YFormatter = value => value.ToString("C");

            //    DataContext = this;
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
