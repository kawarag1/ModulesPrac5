using ModulesPrac5.Models;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = Helper.GetContext();
                Users user_ = new Users();
                user_.Username = loginbox.Text;
                user_.RegistrationDate = DateTime.Now;
                user_.Email = emailbox.Text;
                user_.PasswordHash = Hash.HashPassword(pwdbox.Password.ToString());
                context.Users.Add(user_);
                context.SaveChanges();
                UserHelper.user = user_;
                MessageBox.Show("Успешно!");
                NavigationService.GoBack();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
