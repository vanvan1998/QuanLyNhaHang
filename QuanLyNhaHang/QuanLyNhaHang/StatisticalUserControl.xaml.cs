using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for StatisticalUserControl.xaml
    /// </summary>
    public partial class StatisticalUserControl : UserControl
    {
        public StatisticalUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 30;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            if (Week.IsChecked == true)
            {
                GridMain.Children.Add(new Statistical.WeekStatisticalUserControl());
            }
            if (Month.IsChecked == true)
            {
                GridMain.Children.Add(new Statistical.MonthStatisticalUserControl());
            }
            if (Quarter.IsChecked == true)
            {
                GridMain.Children.Add(new Statistical.QuarterStatisticalUserControl());
            }
            if (Year.IsChecked == true)
            {
                GridMain.Children.Add(new Statistical.YearStatisticalUserControl());
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //((ToggleButton)sender).IsChecked
            Week.IsChecked = false;
            Month.IsChecked = false;
            Quarter.IsChecked = false;
            Year.IsChecked = false;
            ((ToggleButton)sender).IsChecked = true;
        }
    }
}
