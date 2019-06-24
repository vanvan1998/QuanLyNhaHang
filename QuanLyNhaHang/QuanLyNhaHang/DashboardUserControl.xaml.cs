using System;
using System.Collections.ObjectModel;
using System.Globalization;
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
        LiveCharts.Defaults.ObservableValue countstandard4 = new LiveCharts.Defaults.ObservableValue();
        LiveCharts.Defaults.ObservableValue countstandard8 = new LiveCharts.Defaults.ObservableValue();
        LiveCharts.Defaults.ObservableValue countstandard12 = new LiveCharts.Defaults.ObservableValue();

        LiveCharts.Defaults.ObservableValue countVIP4 = new LiveCharts.Defaults.ObservableValue();
        LiveCharts.Defaults.ObservableValue countVIP8 = new LiveCharts.Defaults.ObservableValue();
        LiveCharts.Defaults.ObservableValue countVIP12 = new LiveCharts.Defaults.ObservableValue();

        public SeriesCollection SeriesCollection1 { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }

        public DashboardUserControl()
        {
            InitializeComponent();

            UsingTables.Text = "0";
            EmptyTables.Text = "0";
            NewBills.Text = "0";

            SeriesCollection1 = new SeriesCollection {
                new PieSeries
                {
                    Title = "Bàn 4 người",
                    Values = new ChartValues<ObservableValue> {countstandard4},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 8 người",
                    Values = new ChartValues<ObservableValue> { countstandard8 },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 12 người",
                    Values = new ChartValues<ObservableValue> { countstandard12 },
                    DataLabels = true
                },

            };

            SeriesCollection2 = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Bàn 4 người",
                    Values = new ChartValues<ObservableValue> { countVIP4 },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 8 người",
                    Values = new ChartValues<ObservableValue> {countVIP8 },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Bàn 12 người",
                    Values = new ChartValues<ObservableValue> { countVIP12 },
                    DataLabels = true
                },

            };

            DataContext = this;

            LoadData();
        }

        private async void LoadData()
        {
            await Task.Run(() =>
            {
               
                string result1 = API.CountTableUsing();
                dynamic stuff1 = JsonConvert.DeserializeObject(result1);

                if (result1 == "")
                {
                    return;
                }

                string result2 = API.CountTableEmpty();
                dynamic stuff2 = JsonConvert.DeserializeObject(result2);

                if (result1 == "")
                {
                    return;
                }

                DateTime today = DateTime.Today;
                string startTime = today.ToString("o", CultureInfo.CreateSpecificCulture("en-US"));

                string result3 = API.Filter(startTime.Substring(0, 10), startTime.Substring(0, 10));
                dynamic stuff3 = JsonConvert.DeserializeObject(result3);

                if (result1 == "")
                {
                    return;
                }

                this.Dispatcher.Invoke(() =>
                {
                    NewBills.Text = stuff3.Count.ToString();

                    UsingTables.Text = stuff1.count;

                    EmptyTables.Text = stuff2.count;

                    countstandard4.Value = stuff2.countstandard4;
                    countstandard8.Value = stuff2.countstandard8;
                    countstandard12.Value = stuff2.countstandard12;

                    countVIP4.Value = stuff2.countVIP4;
                    countVIP8.Value = stuff2.countVIP8;
                    countVIP12.Value = stuff2.countVIP12;
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