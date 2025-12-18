using ModulesPrac5.Services;
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

namespace ModulesPrac5.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Reg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var context = Helper.GetContext();
            string login = loginbox.Text;
            string password = pwdbox.Password.ToString();
            string hashpwd = Hash.HashPassword(password);

            var user = context.Users.Where(x => x.Username == login && x.PasswordHash == hashpwd).FirstOrDefault();
            if (user != null)
            {
                UserHelper.user = user;
                MessageBox.Show("Успешно!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Проверьте логин или пароль");
            }
        }
    }
}
