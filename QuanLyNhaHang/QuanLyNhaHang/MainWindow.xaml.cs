﻿using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using QuanLyNhaHang.Model;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Employee employee = null;
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.IsLoginSuccess == true)
            {
                this.Show();
                employee = LoginWindow.employee;
                EmployeeName.Content = employee.displayName;
                if (employee.role == "admin") // quản lý
                {
                    Statistical.Visibility = Visibility.Visible;
                    Setting.Visibility = Visibility.Visible;
                }
                else if (employee.role == "employee") // nhân viên
                {
                    Statistical.Visibility = Visibility.Hidden;
                    Setting.Visibility = Visibility.Hidden;
                }
                GridMain.Children.Add(new DashboardUserControl());
                Title.Content = "Dashboard";

            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            GridMain.Children.Clear();
            if (employee == null)
            {
                employee = new Employee();
                employee.role = "admin";
            }
            if (employee.role == "employee") // nhân viên
            {
                switch (index)
                {
                    case 0:
                        GridMain.Children.Add(new DashboardUserControl());
                        Title.Content = "Dashboard";
                        break;
                    case 1:
                        GridMain.Children.Add(new EmptyTables.EmptyTablesUserControl());
                        Title.Content = "Đặt Phòng";
                        break;
                    case 2:
                        GridMain.Children.Add(new UsingTables.UsingTablesUserControl());
                        Title.Content = "Thanh Toán";
                        break;
                    case 3:
                        GridMain.Children.Add(new SearchUserControl());
                        Title.Content = "Tìm Kiếm";
                        break;
                    default:
                        break;
                }
            }
            else if (employee.role == "admin") // quản lý
            {
                switch (index)
                {
                    case 0:
                        GridMain.Children.Add(new DashboardUserControl());
                        Title.Content = "Dashboard";
                        break;
                    case 1:
                        GridMain.Children.Add(new EmptyTables.EmptyTablesUserControl());
                        Title.Content = "Đặt Bàn";
                        break;
                    case 2:
                        GridMain.Children.Add(new UsingTables.UsingTablesUserControl());
                        Title.Content = "Thanh Toán";
                        break;
                    case 3:
                        GridMain.Children.Add(new SearchUserControl());
                        Title.Content = "Tìm Kiếm";
                        break;
                    case 4:
                        GridMain.Children.Add(new StatisticalUserControl());
                        Title.Content = "Thống Kê";
                        break;
                    case 5:
                        GridMain.Children.Add(new Setting.SettingUserControl());
                        Title.Content = "Cài đặt";
                        break;
                    default:
                        break;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = SystemParameters.WorkArea.Left;
            this.Top = SystemParameters.WorkArea.Top;
            this.Height = SystemParameters.WorkArea.Height;
            this.Width = SystemParameters.WorkArea.Width;
        }

        private void MoveCursorMenu(int index)
        {
            GridCursor.Margin = new Thickness(0, (60 * index), 0, 0);
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            this.Hide();

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            XDocument objDoc = XDocument.Load(path + "/Config/Rememberme.xml");

            objDoc.Root.Elements().ElementAt(0).Value = "False";

            objDoc.Save(path + "/Config/Rememberme.xml");

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.IsLoginSuccess == true)
            {
                this.Show();
                employee = LoginWindow.employee;
                EmployeeName.Content = employee.displayName;
                if (employee.role == "admin") // quản lý
                {
                    Statistical.Visibility = Visibility.Visible;
                    Setting.Visibility = Visibility.Visible;
                }
                else if (employee.role == "employee") // nhân viên
                {
                    Statistical.Visibility = Visibility.Hidden;
                    Setting.Visibility = Visibility.Hidden;
                }
                GridMain.Children.Add(new DashboardUserControl());
                Title.Content = "Dashboard";

            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
