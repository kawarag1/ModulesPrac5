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
    /// Логика взаимодействия для OrderDetailsPage.xaml
    /// </summary>
    public partial class OrderDetailsPage : Page
    {
        public OrderDetailsPage(Orders order)
        {
            InitializeComponent();
            GetOrderList(order.ID);
        }

        private void GetOrderList(int orderID)
        {
            try
            {
                var context = Helper.GetContext();
                LVOrders.ItemsSource = context.OrderItems.Where(x => x.OrderID == orderID).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
