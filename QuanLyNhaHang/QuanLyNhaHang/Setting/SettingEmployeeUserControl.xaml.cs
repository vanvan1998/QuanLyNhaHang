using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for SettingEmployeeUserControl.xaml
    /// </summary>
    public partial class SettingEmployeeUserControl : UserControl
    {
        ObservableCollection<Model.Employee> Employees = new ObservableCollection<Model.Employee>();

        public SettingEmployeeUserControl()
        {
            InitializeComponent();

            ListViewEmployee.ItemsSource = Employees;

            Load();
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                string result = API.GetAllEmployee();
                dynamic stuff = JsonConvert.DeserializeObject(result);

                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in stuff)
                    {
                        Employees.Add(new Model.Employee()
                        {
                            id = item._id,
                            username = item.username,
                            password = item.password,
                            displayName = item.displayName,
                            role = item.role,
                            identityNumber = item.identityNumber,
                            phone = item.phone,
                            dateOfBirth = item.dateOfBirth
                        });
                    };
                });
            });
            LoadTicket();
        }

        private async void LoadTicket()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < Employees.Count; i++)
                    {
                        if (Employees[i].role == "employee")
                        {
                            ListViewItem lvi1 = ListViewEmployee.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                            var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                            var dt1 = cp1.ContentTemplate as DataTemplate;
                            var rt1 = (Grid)dt1.FindName("TicketType", cp1);
                            rt1.Background = Brushes.Blue;
                        }
                    };
                });
            });
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Application.Current.MainWindow.ActualWidth - 70;
            this.Height = Application.Current.MainWindow.ActualHeight - 50;

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void ListViewEmployee_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedIndex == -1)
            {
                return;
            }

            if (((ListView)sender).ItemContainerGenerator.ContainerFromIndex(((ListView)sender).SelectedIndex) is ListViewItem lvi)
            {


                var bc = new BrushConverter();

                for (int j = 0; j < Employees.Count; j++)
                {
                    ListViewItem lvi1 = ListViewEmployee.ItemContainerGenerator.ContainerFromIndex(j) as ListViewItem;
                    var cp1 = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi1);

                    var dt1 = cp1.ContentTemplate as DataTemplate;
                    var rt1 = (Rectangle)dt1.FindName("BackGround", cp1);
                    var tb1 = (TextBlock)dt1.FindName("Username", cp1);
                    rt1.Fill = Brushes.White;
                }

                var cp = VisualTreeHelperExtensions.FindVisualChild<ContentPresenter>(lvi);

                var dt = cp.ContentTemplate as DataTemplate;
                var rt = (Rectangle)dt.FindName("BackGround", cp);
                var tb = (TextBlock)dt.FindName("Username", cp);
                Model.Employee employeeSelected = new Model.Employee();

                foreach (var item in Employees)
                {
                    if (item.username == tb.Text)
                    {
                        employeeSelected = item;
                        break;
                    }
                };

                Username.Text = employeeSelected.username;
                NameEmployee.Text = employeeSelected.displayName;
                DateOfBirth.Text = employeeSelected.dateOfBirth;
                IdentityNumber.Text = employeeSelected.identityNumber;
                Phone.Text = employeeSelected.phone;
                if (employeeSelected.role == "admin")
                {
                    TypeEmployee.SelectedIndex = 1;
                }
                else
                {
                    TypeEmployee.SelectedIndex = 0;
                }

                id.Text = employeeSelected.id;

                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;

                rt.Fill = (Brush)bc.ConvertFrom("#FF0BD9EE");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Model.Employee employeeNew = new Model.Employee();
            employeeNew.username = Username.Text;
            employeeNew.displayName = NameEmployee.Text;
            employeeNew.dateOfBirth = DateOfBirth.Text;
            employeeNew.identityNumber = IdentityNumber.Text;
            employeeNew.phone = Phone.Text;
            if (Password.Password == "")
            {
                MessageBox.Show("Password trống!!!");
                return;
            }
            using (MD5 md5Hash = MD5.Create())
            {
                employeeNew.password = GetMd5Hash(md5Hash, Password.Password);

            }
            if (TypeEmployee.SelectedIndex == 1)
            {
                employeeNew.role = "admin";
            }
            else
            {
                employeeNew.role = "employee";
            }

            foreach (var item in Employees)
            {
                if (item.username == Username.Text)
                {
                    MessageBox.Show("Username đã có!!!\n Bạn vui lòng chọn username khác!");
                    return;
                }
            };

            string result = API.CreateEmployee(employeeNew);
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "create successful")
            {
                MessageBox.Show("Tạo nhân viên thành công!!!");
                Employees.Clear();
                Load();
                LoadEmpty();
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra trong quá trình tạo nhân viên, vui lòng thử lại!!!");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi xóa!!!");
                return;
            }
            string result = API.DeleteEmployee(id.Text);
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "Employee deleted successfully!")
            {
                MessageBox.Show("Xóa nhân viên thành công!!!");
                Employees.Clear();
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

            Model.Employee employeeNew = new Model.Employee();
            if (id.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi cập nhật!!!");
                return;
            }
            employeeNew.id = id.Text;
            employeeNew.username = Username.Text;
            employeeNew.displayName = NameEmployee.Text;
            employeeNew.dateOfBirth = DateOfBirth.Text;
            employeeNew.identityNumber = IdentityNumber.Text;
            employeeNew.phone = Phone.Text;


            if (TypeEmployee.SelectedIndex == 1)
            {
                employeeNew.role = "admin";
            }
            else
            {
                employeeNew.role = "employee";
            }
            foreach (var item in Employees)
            {
                if (item.username == Username.Text && item.id != id.Text)
                {
                    MessageBox.Show("Username đã có!!!\n Bạn vui lòng chọn username khác!");
                    return;
                }
            };
            string result = "";
            if (Password.Password == "")
            {
                result = API.UpdateEmployee(employeeNew);

            }
            else
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    employeeNew.password = GetMd5Hash(md5Hash, Password.Password);

                }
                result = API.UpdatePassword(employeeNew);
            }
            dynamic stuff = JsonConvert.DeserializeObject(result);
            if (stuff.message == "Employee updated successfully!")
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!!!");
                Employees.Clear();
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
            string result = API.GetAllEmployee();
            dynamic stuff = JsonConvert.DeserializeObject(result);
            Employees.Clear();
            ListViewEmployee.ItemsSource = Employees;
            

            Boolean search = false;
            string Query = TbSearch.Text.ToUpper();
            foreach (var item in stuff)
            {
                string employeeInList = item.username.ToString().ToUpper();
                if (employeeInList.IndexOf(Query) != -1 || Query.IndexOf(employeeInList) != -1)
                {
                    search = true;
                    Employees.Add(new Model.Employee()
                    {
                        id = item._id,
                        username = item.username,
                        displayName = item.displayName,
                        role = item.role,
                        password = item.password,
                        dateOfBirth = item.dateOfBirth,
                        identityNumber = item.identityNumber,
                        phone = item.phone
                    });
                }
            };
            LoadTicket();
            if (search == false)
            {
                MessageBox.Show("Username bạn nhập không tồn tại!!!");
                return;
            }
            LoadEmpty();
        }

        private void LoadEmpty()
        {
            Username.Text = "";
            NameEmployee.Text = "";
            DateOfBirth.Text = "";
            IdentityNumber.Text = "";
            Phone.Text = "";
            TypeEmployee.SelectedIndex = -1;
            id.Text = "";
            Password.Password = "";

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
