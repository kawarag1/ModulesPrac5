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
        }

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());
        }

        private void OrderByName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OrderByCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OrderByCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
