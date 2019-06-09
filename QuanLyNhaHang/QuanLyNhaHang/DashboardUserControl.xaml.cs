using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using QuanLyNhaHang.Model;

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

            UsingTables.Text = "0";
            EmptyTables.Text = "0";

            SeriesCollection1 = new SeriesCollection { };
            SeriesCollection2 = new SeriesCollection { };

            DataContext = this;

            LoadData();
        }

        private async void LoadData()
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    string result = API.CountTableUsing();
                    dynamic stuff = JsonConvert.DeserializeObject(result);

                    UsingTables.Text = stuff.count;

                    result = API.CountTableEmpty();
                    stuff = JsonConvert.DeserializeObject(result);

                    EmptyTables.Text = stuff.count;

                    int countVIP4 = stuff.countVIP4;
                    int countVIP8 = stuff.countVIP8;
                    int countVIP12 = stuff.countVIP12;
                    int countstandard4 = stuff.countstandard4;
                    int countstandard8 = stuff.countstandard8;
                    int countstandard12 = stuff.countstandard12;

                    SeriesCollection1 = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Bàn 4 người",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(countstandard4) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 8 người",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(countstandard8) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 12 người",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(countstandard12) },
                    DataLabels = true
                },

            };

                    SeriesCollection2 = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Bàn 4 người",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(countVIP4) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 8 người",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(countVIP8) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 12 người",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(countVIP12) },
                    DataLabels = true
                },

            };

                    DataContext = this;
                });
            });

        }
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 0;
        }
    }
}