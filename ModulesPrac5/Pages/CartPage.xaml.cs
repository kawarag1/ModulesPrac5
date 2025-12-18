using ModulesPrac5.Models;
using ModulesPrac5.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public static Users user_;
        public CartPage(Users user)
        {
            InitializeComponent();
            user_ = user;
            InitializeCarts();
        }

        private void InitializeCarts()
        {
            var context = Helper.GetContext();
            var carts = context.Carts.Where(x => x.UserID == user_.ID).Include("Products").ToList();
            LVCarts.ItemsSource = carts;
            CartsSumProdcuts.Text = "Количество уникальных товаров: " + carts.Count.ToString();
            decimal sum = 0;
            foreach (var cart in carts)
            {
                sum += cart.Products.Price;
            }
            CartCost.Text = sum.ToString() + "₽";
        }
        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
