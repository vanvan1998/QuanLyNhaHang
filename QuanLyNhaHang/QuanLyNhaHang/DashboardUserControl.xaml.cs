using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
//using QuanLyNhaHang.Entity;

namespace QuanLyNhaHang
{
    
    public partial class DashboardUserControl : UserControl
    {
        public SeriesCollection SeriesCollection1 { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }
        public SeriesCollection SeriesCollection3 { get; set; }

        public DashboardUserControl()
        {
            InitializeComponent();

            //UsingTables.Text = DataProvider.Ins.DB.Phongs.Where(x => x.tinhTrang == 1 && x.daXoa == 0).Count().ToString();
            //EmptyTables.Text = DataProvider.Ins.DB.Phongs.Where(x => x.tinhTrang == 0 && x.daXoa == 0).Count().ToString();
            //NewBills.Text = DataProvider.Ins.DB.HoaDons.Where(x => x.thoiGianLap > DateTime.Today).Count().ToString();

            //SeriesCollection1 = new SeriesCollection
            //{
            //    new PieSeries
            //    {
            //        Title = "Phòng đơn",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(DataProvider.Ins.DB.Phongs.Where(x => x.loaiPhong == "Tiêu chuẩn - Đơn" && x.tinhTrang == 0 && x.daXoa == 0).ToList().Count())},
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Phòng đôi",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(DataProvider.Ins.DB.Phongs.Where(x => x.loaiPhong == "Tiêu chuẩn - Đôi" && x.tinhTrang == 0 && x.daXoa == 0).ToList().Count())},
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Phòng nhóm",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(DataProvider.Ins.DB.Phongs.Where(x => x.loaiPhong == "Tiêu chuẩn - Nhóm" && x.tinhTrang == 0 && x.daXoa == 0).ToList().Count())},
            //        DataLabels = true
            //    },

            //};

            //SeriesCollection2 = new SeriesCollection
            //{
            //    new PieSeries
            //    {
            //        Title = "Phòng đơn",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(DataProvider.Ins.DB.Phongs.Where(x => x.loaiPhong == "VIP - Đơn" && x.tinhTrang == 0 && x.daXoa == 0).ToList().Count())},
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Phòng đôi",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(DataProvider.Ins.DB.Phongs.Where(x => x.loaiPhong == "VIP - Đôi" && x.tinhTrang == 0&& x.daXoa == 0).ToList().Count())},
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Phòng nhóm",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(DataProvider.Ins.DB.Phongs.Where(x => x.loaiPhong == "VIP - Nhóm" && x.tinhTrang == 0 && x.daXoa ==0).ToList().Count()) },
            //        DataLabels = true
            //    },

            //};

            //DataContext = this;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 30;
        }
    }
}