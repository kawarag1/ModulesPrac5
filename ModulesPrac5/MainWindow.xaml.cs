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
using ModulesPrac5.Pages;
using ModulesPrac5.Services;

namespace ModulesPrac5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new ShopPage());
        }

        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrmMain.Content is ShopPage)
            {
                Title.Text = "Магазин";
                BackBtn.Visibility = Visibility.Hidden;
                if (UserHelper.user is null)
                {
                    AuthOrRegBtn.Visibility = Visibility.Visible;
                    ExitButton.Visibility = Visibility.Hidden;
                    OrdersButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    AuthOrRegBtn.Visibility = Visibility.Hidden;
                    ExitButton.Visibility = Visibility.Visible;
                    OrdersButton.Visibility = Visibility.Visible;
                }
            }
            else if (FrmMain.Content is AuthPage)
            {
                Title.Text = "Авторизация";
                BackBtn.Visibility = Visibility.Visible;
                AuthOrRegBtn.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Hidden;
            }
            else if (FrmMain.Content is RegPage)
            {
                Title.Text = "Регистрация";
                BackBtn.Visibility = Visibility.Visible;
                AuthOrRegBtn.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Hidden;
            }
            else if (FrmMain.Content is CartPage)
            {
                Title.Text = "Корзина";
                BackBtn.Visibility = Visibility.Visible;
                AuthOrRegBtn.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Visible;
                OrdersButton.Visibility = Visibility.Visible;
            }
            else if (FrmMain.Content is OrdersPage)
            {
                Title.Text = "Заказы";
                BackBtn.Visibility = Visibility.Visible;
                AuthOrRegBtn.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Visible;
                OrdersButton.Visibility = Visibility.Visible;
            }
            else if (FrmMain.Content is OrderDetailsPage)
            {
                Title.Text = "Детали заказа";
                BackBtn.Visibility = Visibility.Visible;
                AuthOrRegBtn.Visibility = Visibility.Hidden;
                OrdersButton.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Hidden;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.GoBack();
        }

        private void AuthOrRegBtn_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new AuthPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            UserHelper.user = null;
            ExitButton.Visibility = Visibility.Hidden;
            AuthOrRegBtn.Visibility = Visibility.Visible;
            OrdersButton.Visibility = Visibility.Hidden;
            MessageBox.Show("Вы вышли из аккаунта!");
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserHelper.user == null)
            {
                MessageBox.Show("Вы не авторизованы!");
            }
            else
            {
                FrmMain.Navigate(new OrdersPage(UserHelper.user));
            }
        }
    }
}
