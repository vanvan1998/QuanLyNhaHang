using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for PriceListUserControl.xaml
    /// </summary>
    public partial class PriceListUserControl : UserControl
    {
        ObservableCollection<Model.Food> Foods = new ObservableCollection<Model.Food>();

        public PriceListUserControl()
        {
            InitializeComponent();

            ListViewFood.ItemsSource = Foods;

            Load();
        }

        private async void Load()
        {


            await Task.Run(() =>
            {
                string result = API.GetAllFood();
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        Foods.Add(new Model.Food()
                        {
                            id = item._id,
                            name = item.name,
                            type = item.type,
                            ingredients = item.ingredients,
                            note = item.note,
                            price = item.price
                        });
                    };
                });
            });

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(() =>
                {
                    TicketType();
                });
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 50;

        }

        private void TicketType()
        {
            for (int i = 0; i < Foods.Count; i++)
            {
                if (Foods[i].type == "dessert")
                {
                    ListViewItem lvi1 = ListViewFood.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Grid)dt1.FindName("TicketType", cp1);
                    rt1.Background = Brushes.Pink;
                }

                if (Foods[i].type == "appetizer")
                {
                    ListViewItem lvi1 = ListViewFood.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Grid)dt1.FindName("TicketType", cp1);
                    rt1.Background = Brushes.Blue;
                }
            };
        }

        private void ListViewFood_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {


                var bc = new BrushConverter();

                for (int j = 0; j < Foods.Count; j++)
                {
                    ListViewItem lvi1 = ListViewFood.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NameFood", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NameFood", cp);
                Model.Food foodSelected = new Model.Food();

                foreach (var item in Foods)
                {
                    if (item.name == tb.Text)
                    {
                        foodSelected = item;
                        break;
                    }
                };

                NameFood.Text = foodSelected.name;
                Price.Text = foodSelected.price;
                Ingredients.Text = foodSelected.ingredients;
                Note.Text = foodSelected.note;

                if (foodSelected.type == "appetizer")
                {
                    TypeFood.SelectedIndex = 0;
                }
                else if (foodSelected.type == "dish")
                {
                    TypeFood.SelectedIndex = 1;
                }
                else
                {
                    TypeFood.SelectedIndex = 2;
                }

                id.Text = foodSelected.id;

                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Model.Food foodNew = new Model.Food();
            foodNew.name = NameFood.Text;
            foodNew.price = Price.Text;
            foodNew.ingredients = Ingredients.Text;
            foodNew.note = Note.Text;

            if (TypeFood.SelectedIndex == 0)
            {
                foodNew.type = "appetizer";
            }
            else if (TypeFood.SelectedIndex == 1)
            {
                foodNew.type = "dish";
            }
            else
            {
                foodNew.type = "dessert";
            }

            foreach (var item in Foods)
            {
                if (item.name == NameFood.Text)
                {
                    MessageBox.Show("Tên món ăn đã có!!!\n Bạn vui lòng chọn tên khác!");
                    return;
                }
            };

            string result = API.CreateFood(foodNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "create successful")
            {
                MessageBox.Show("Tạo món ăn thành công!!!");
                Foods.Clear();
                Load();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình tạo món ăn, vui lòng thử lại!!!");
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn món ăn trước khi xóa!!!");
                return;
            }
            string result = API.DeleteFood(id.Text);
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "Food deleted successfully!")
            {
                MessageBox.Show("Xóa món ăn thành công!!!");
                Foods.Clear();
                Load();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình xóa, vui lòng thử lại!!!");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            Model.Food foodNew = new Model.Food();
            if (id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn món ăn trước khi cập nhật!!!");
                return;
            }
            foodNew.id = id.Text;
            foodNew.name = NameFood.Text;
            foodNew.price = Price.Text;
            foodNew.ingredients = Ingredients.Text;
            foodNew.note = Note.Text;

            if (TypeFood.SelectedIndex == 0)
            {
                foodNew.type = "appetizer";
            }
            else if (TypeFood.SelectedIndex == 1)
            {
                foodNew.type = "dish";
            }
            else
            {
                foodNew.type = "dessert";
            }
            foreach (var item in Foods)
            {
                if (item.name == NameFood.Text && item.id != id.Text)
                {
                    MessageBox.Show("Tên món ăn đã có!!!\n Bạn vui lòng chọn tên khác!");
                    return;
                }
            };

            string result = API.UpdateFood(id.Text, foodNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "Food updated successfully!")
            {
                MessageBox.Show("Cập nhật thông tin món ăn thành công!!!");
                Foods.Clear();
                Load();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình cập nhật, vui lòng thử lại!!!");
            }

        }
    }
}
