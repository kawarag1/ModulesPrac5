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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public static Users user_;
        public OrdersPage(Users user)
        {
            InitializeComponent();
            user_ = user;
            InitializeOrders();
        }

        private void InitializeOrders()
        {
            var context = Helper.GetContext();
            var orders = context.Orders.Where(x => x.UserID == user_.ID).ToList();
            OrdersLView.ItemsSource = orders;
        }
    }
}
