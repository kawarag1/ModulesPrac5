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
using System.Xml.Serialization;

namespace ModulesPrac5.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public List<Products> products_;
        public List<Products> products__;

        public ShopPage()
        {
            InitializeComponent();
            InitializeProducts();
            InitializeCategories();
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserHelper.user == null)
            {
                MessageBox.Show("Вы не авторизованы!");
            }
            else
            {
                NavigationService.Navigate(new CartPage(UserHelper.user));
            }
        }

        private void InitializeProducts()
        {
            LViewItems.ItemsSource = null;
            var context = Helper.GetContext();
            products_ = context.Products.ToList();
            products__ = context.Products.ToList();
            LViewItems.ItemsSource = products_;
        }
    
        private void UpdateListProducts()
        {
            LViewItems.ItemsSource = products__;
        }

        private void InitializeCategories()
        {
            try
            {
                var context = Helper.GetContext();
                OrderByCategories.ItemsSource = context.CategoriesProducts.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderByName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderByName.SelectedIndex == 0)
            {
                LViewItems.ItemsSource = null;
                LViewItems.ItemsSource = products_.OrderBy(x => x.Name).ToList();
            }
            else if (OrderByName.SelectedIndex == 1)
            {
                LViewItems.ItemsSource = null;
                LViewItems.ItemsSource = products_.OrderByDescending(x => x.Name).ToList();
            }
        }

        private void OrderByCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderByCost.SelectedIndex == 0)
            {
                LViewItems.ItemsSource = products_.OrderBy(x => x.Price).ToList();
            }
            else if (OrderByCost.SelectedIndex == 1)
            {
                LViewItems.ItemsSource = products_.OrderByDescending(x => x.Price).ToList();
            }
        }

        private void OrderByCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LViewItems.ItemsSource = products_.Where(x => x.CategoryID == OrderByCategories.SelectedIndex + 1).ToList();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (UserHelper.user == null)
            {
                MessageBox.Show("Вы не авторизованы!");
            }
            else
            {
                try
                {
                    var button = sender as Button;
                    var item = button.DataContext as Products;
                    var context = Helper.GetContext();

                    var product_ = context.Carts.Where(x => x.UserID == UserHelper.user.ID && x.ProductID == item.ID).FirstOrDefault();
                    if (product_ != null)
                    {
                        product_.Quantity += 1;
                        context.SaveChanges();
                        MessageBox.Show("Успешно!");
                    }
                    else
                    {
                        var cart = new Carts();
                        cart.Quantity = 1;
                        cart.ProductID = item.ID;
                        cart.UserID = UserHelper.user.ID;
                        context.Carts.Add(cart);
                        context.SaveChanges();
                        MessageBox.Show("Успешно!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {
            UpdateListProducts();
            OrderByName.SelectedItem = null;
            OrderByCategories.SelectedItem = null;
            OrderByCost.SelectedItem = null;
        }
    }
}
