using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyNhaHang.Setting
{
    /// <summary>
    /// Interaction logic for UserControlUsingTable.xaml
    /// </summary>

    public partial class SettingUserControl : UserControl
    {

        public SettingUserControl()
        {
            InitializeComponent();

            GridMain.Children.Add(new SettingTableUserControl());

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 30;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (300 * index), 0, 0, 0);
            GridMain.Children.Clear();

            switch (index)
            {
                case 0:
                    GridMain.Children.Add(new SettingTableUserControl());
                    break;
                case 1:
                    GridMain.Children.Add(new SettingEmployeeUserControl());
                    break;
                case 2:
                    GridMain.Children.Add(new PriceListUserControl());
                    break;
            }
        }
    }
}
