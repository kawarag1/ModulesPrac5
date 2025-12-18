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
            var context = Helper.GetContext();
            Orders order = new Orders();
            order.UserID = user_.ID;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = Convert.ToDecimal(CartCost.Text);
            order.Status = 1;
            context.Orders.Add(order);
            context.SaveChanges();

            foreach (Carts product in LVCarts.Items)
            {
                OrderItems item_ = new OrderItems();
                item_.OrderID = order.ID;
                item_.ProductID = product.ProductID;
                item_.Quantity = product.Quantity;
                item_.PriceAtOrder = product.Products.Price;
                context.OrderItems.Add(item_);
            }
            context.SaveChanges();
        }

        private void DeleteFromCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button.DataContext as Carts;

            var context = Helper.GetContext();
            context.Carts.Remove(item);
            context.SaveChanges();
        }
    }
}
