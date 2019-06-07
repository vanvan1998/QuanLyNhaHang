using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Newtonsoft.Json;
using QuanLyNhaHang.Model;
namespace QuanLyNhaHang.Setting
{
    /// <summary>
    /// Interaction logic for SettingTableUserControl.xaml
    /// </summary>
    public partial class SettingTableUserControl : UserControl
    {
        ObservableCollection<Model.Table> Tables = new ObservableCollection<Model.Table>();
        ListView lvHienTai = null;
        ListViewItem lviHienTai = null;

        public SettingTableUserControl()
        {
            InitializeComponent();
            string result = API.GetAllTable();
            dynamic stuff = JsonConvert.DeserializeObject(result);
            foreach (var item in stuff)
            {
                Tables.Add(new Model.Table()
                {
                    number = item.number,
                    numberOfSeat = item.numberOfSeat,
                    type=item.type,
                    status = item.status,
                    customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
                });
            };

            ListViewTable.ItemsSource = Tables;

            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].type == "VIP")
                {
                    ListViewItem lvi1 = ListViewTable.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("TicketType", cp1);
                    rt1.Fill = Brushes.White;
                }
            };
            //Task t = new Task(() =>
            //{
            //    string result = API.GetAllTable();
            //    dynamic stuff = JsonConvert.DeserializeObject(result);

            //    foreach (var item in stuff)
            //    {
            //        Tables.Add(new Model.Table()
            //        {
            //            number = item.number,
            //            numberOfSeat = item.numberOfSeat,
            //            status = item.status,
            //            customer = new Customer() { fullName = item.customer.fullName, phone = item.customer.phone }
            //        });
            //    };

            //    ListViewTable.ItemsSource = Tables;
            //});
            //t.Start();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 80;
        }

        private void ListViewTable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {


                var bc = new BrushConverter();

                for (int j = 0; j < Tables.Count; j++)
                {
                    ListViewItem lvi1 = ListViewTable.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NumberTable", cp1);
                    var tbNumberOfSeat1 = (TextBlock)dt1.FindName("TypeTable", cp1);
                    var tbcustomer1 = (TextBlock)dt1.FindName("CustomerName", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NumberTable", cp);
                var tbNumberOfSeat = (TextBlock)dt.FindName("TypeTable", cp);
                var tbcustomer = (TextBlock)dt.FindName("CustomerName", cp);
                Model.Table tableSelected = new Model.Table();

                foreach (var item in Tables)
                {
                    if (item.number == tb.Text)
                        tableSelected = item;
                };

                NumberTable.Text = tableSelected.number;
                TypeTable.Text = tableSelected.type;
                NumberOfSeat.Text = "Bàn " + tableSelected.numberOfSeat + " người";
                CustomerName.Text = tableSelected.customer.fullName;
                Phone.Text = tableSelected.customer.phone;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
