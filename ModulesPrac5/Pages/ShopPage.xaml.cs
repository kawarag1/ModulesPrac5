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
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public ShopPage()
        {
            InitializeComponent();
            InitializeProducts();
            InitializeCategories();
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());
        }

        private void InitializeProducts()
        {
            var context = Helper.GetContext();
            var products = context.Products;
            LViewItems.ItemsSource = products;
        }

        private void InitializeCategories()
        {
            var context = Helper.GetContext();
            OrderByCategories.ItemsSource = context.CategoriesProducts.ToList();
        }

        private void OrderByName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = Helper.GetContext();
            if (OrderByName.SelectedItem.ToString() == "А - Я")
            {
                LViewItems.ItemsSource = null;
                LViewItems.ItemsSource = context.Products.OrderBy(x => x.Name);
            }
            else if (OrderByName.SelectedItem.ToString() == "Я - А")
            {
                LViewItems.ItemsSource = null;
                LViewItems.ItemsSource = context.Products.OrderByDescending(x => x.Name);
            }
        }

        private void OrderByCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = Helper.GetContext();
            if (OrderByName.SelectedItem.ToString() == "По возрастанию цены")
            {
                LViewItems.ItemsSource = null;
                LViewItems.ItemsSource = context.Products.OrderBy(x => x.Price);
            }
            else if (OrderByName.SelectedItem.ToString() == "По убыванию цены")
            {
                LViewItems.ItemsSource = null;
                LViewItems.ItemsSource = context.Products.OrderByDescending(x => x.Price);
            }
        }

        private void OrderByCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = Helper.GetContext();
            LViewItems.ItemsSource = null;
            LViewItems.ItemsSource = context.Products.Where(x => x.CategoryID == OrderByCategories.SelectedIndex + 1).ToList();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (UserHelper.user == null)
            {
                MessageBox.Show("Вы не авторизованы!");
            }
            else
            {
                var button = sender as Button;
                var item = button.DataContext as Products;
                var context = Helper.GetContext();

                var product_ = context.Carts.Where(x => x.UserID == UserHelper.user.ID && x.ProductID == item.ID).FirstOrDefault();
                if (product_ != null)
                {
                    product_.Quantity += 1;
                    context.SaveChanges();
                }
                else
                {
                    var cart = new Carts();
                    cart.Quantity = 1;
                    cart.ProductID = item.ID;
                    cart.UserID = UserHelper.user.ID;
                    context.Carts.Add(cart);
                    context.SaveChanges();
                }
            }
        }
    }
}
