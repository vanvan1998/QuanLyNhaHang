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
    public partial class PromotionUserControl : UserControl
    {
        ObservableCollection<Model.Promotion> Promotions = new ObservableCollection<Model.Promotion>();

        public PromotionUserControl()
        {
            InitializeComponent();

            ListViewPromotion.ItemsSource = Promotions;

            Load();
        }

        private async void Load()
        {


            await Task.Run(() =>
            {
                string result = API.GetAllPromotion();
                dynamic stuff = JsonConvert.DeserializeObject(result);

                if (result == "")
                {
                    return;
                }

                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        Promotions.Add(new Model.Promotion()
                        {
                            id=item._id,
                            code = item.code,
                            type = item.type,
                            value = item.value,
                            active = item.active,
                            rule = item.rule
                        });
                    };
                });
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 50;

        }
        private void ListViewPromotion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {
                var bc = new BrushConverter();

                for (int j = 0; j < Promotions.Count; j++)
                {
                    ListViewItem lvi1 = ListViewPromotion.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("NamePromotion", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("NamePromotion", cp);
                Model.Promotion promotionSelected = new Model.Promotion();

                foreach (var item in Promotions)
                {
                    if (item.code == tb.Text)
                    {
                        promotionSelected = item;
                        break;
                    }
                };

                NamePromotion.Text = promotionSelected.code;
                valuePromotion.Text = promotionSelected.value.ToString();
                if(promotionSelected.type=="percent")
                {
                    TypePromotion.SelectedIndex = 0;
                }
                else
                {
                    TypePromotion.SelectedIndex = 1;
                }
                rulePromotion.Text = promotionSelected.rule;
                if (promotionSelected.active)
                {
                    ActivePromotion.SelectedIndex = 0;
                }
                else
                {
                    ActivePromotion.SelectedIndex = 1;
                }
                id.Text = promotionSelected.id;

                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Model.Promotion promotionNew = new Model.Promotion();
            promotionNew.code = NamePromotion.Text;
            promotionNew.value =int.Parse( valuePromotion.Text);
            promotionNew.rule = rulePromotion.Text;
            if(ActivePromotion.SelectedIndex==0)
            {
                promotionNew.active = true;
            }
            else
            {
                promotionNew.active = false;
            }

            if (TypePromotion.SelectedIndex == 0)
            {
                promotionNew.type = "percent";
            }
            else
            {
                promotionNew.type = "value";
            }

            foreach (var item in Promotions)
            {
                if (item.code == NamePromotion.Text)
                {
                    MessageBox.Show("Mã khuyến mãi đã có!!!\n Bạn vui lòng chọn mã khác!");
                    return;
                }
            };

            string result = API.CreatePromotion(promotionNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            if (stuff.message == "successful")
            {
                MessageBox.Show("Tạo mã thành công!!!");
                Promotions.Clear();
                Load();
                LoadEmpty();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình tạo mã, vui lòng thử lại!!!");
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string result = API.DeletePromotion(id.Text);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            if (stuff.message == "successful")
            {
                MessageBox.Show("Xóa mã khuyến mãi thành công!!!");
                Promotions.Clear();
                Load();
                LoadEmpty();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình xóa, vui lòng thử lại!!!");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            Model.Promotion promotionNew = new Model.Promotion();
            if (id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã trước khi cập nhật!!!");
                return;
            }
            promotionNew.id = id.Text;
            promotionNew.code = NamePromotion.Text;
            promotionNew.value = int.Parse(valuePromotion.Text);
            promotionNew.rule = rulePromotion.Text;
            if (ActivePromotion.SelectedIndex == 0)
            {
                promotionNew.active = true;
            }
            else
            {
                promotionNew.active = false;
            }

            if (TypePromotion.SelectedIndex == 0)
            {
                promotionNew.type = "percent";
            }
            else
            {
                promotionNew.type = "value";
            }
            foreach (var item in Promotions)
            {
                if (item.code == NamePromotion.Text && item.id != id.Text)
                {
                    MessageBox.Show("Mã khuyến mãi đã có!!!\n Bạn vui lòng chọn mã khác!");
                    return;
                }
            };

            string result = API.UpdatePromotion(id.Text, promotionNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            if (stuff.message == "successful")
            {
                MessageBox.Show("Cập nhật thông tin mã khuyến mãi thành công!!!");
                Promotions.Clear();
                Load();
                LoadEmpty();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình cập nhật, vui lòng thử lại!!!");
            }

        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string result = API.GetAllPromotion();
            dynamic stuff = JsonConvert.DeserializeObject(result);

            if (result == "")
            {
                return;
            }

            Promotions.Clear();
            ListViewPromotion.ItemsSource = Promotions;
            
            Boolean search = false;
            string promotionQuery = TbSearch.Text.ToUpper();
            foreach (var item in stuff)
            {
                string promotionInList = item.code.ToString().ToUpper();
                if (promotionInList.IndexOf(promotionQuery) != -1 || promotionQuery.IndexOf(promotionInList) != -1)
                {
                    search = true;
                    Promotions.Add(new Model.Promotion()
                    {
                        id = item._id,
                        code = item.code,
                        type = item.type,
                        value = item.value,
                        active = item.active,
                        rule=item.rule
                    });
                }
            };
            if (search == false)
            {
                MessageBox.Show("Tên món ăn bạn nhập không tồn tại!!!");
                return;
            }
            LoadEmpty();
        }

        private void LoadEmpty()
        {
            NamePromotion.Text = "";
            valuePromotion.Text = "";
            TypePromotion.SelectedIndex=-1;
            rulePromotion.Text = "";
            ActivePromotion.SelectedIndex = -1;

            id.Text = "";
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearch.Text.Length > 0)
            {
                btnSearch.IsEnabled = true;
            }
            else
            {
                btnSearch.IsEnabled = false;
            }
        }
    }
}
