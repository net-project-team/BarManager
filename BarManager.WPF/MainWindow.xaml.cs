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

namespace BarManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MenuItem> menuItems;
        private List<OrderItem> orderItems;
        public MainWindow()
        {
            InitializeComponent();
            menuItems = new List<MenuItem>
        {
            new MenuItem { Name = "Hamburger", Description = "Beef patty, lettuce, tomato, onion, pickles", Price = 5.99m },
            new MenuItem { Name = "Cheeseburger", Description = "Beef patty, cheddar cheese, lettuce, tomato, onion, pickles", Price = 6.49m },
            new MenuItem { Name = "Chicken Sandwich", Description = "Grilled chicken breast, lettuce, tomato, mayo", Price = 6.99m },
            new MenuItem { Name = "French Fries", Description = "Golden brown fries", Price = 2.49m },
            new MenuItem { Name = "Onion Rings", Description = "Crispy breaded onion rings", Price = 3.49m },
            new MenuItem { Name = "Soft Drink", Description = "Coca-Cola, Sprite, or Fanta", Price = 1.99m }
        };

            // Bind the menu items to the list box
            menuListBox.ItemsSource = menuItems;

            // Initialize the order items
            orderItems = new List<OrderItem>();

            // Set the data context for the order summary controls
            orderListBox.ItemsSource = orderItems;
            totalTextBlock.DataContext = orderItems;

            // Handle the selection changed event for the menu items list box
            menuListBox.SelectionChanged += MenuListBox_SelectionChanged;
        }
        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected menu item
            var selectedItem = (MenuItem)menuListBox.SelectedItem;

            if (selectedItem != null)
            {
                // Check if the item is already in the order
                var existingOrderItem = orderItems.FirstOrDefault(x => x.MenuItem == selectedItem);

                if (existingOrderItem != null)
                {
                    // If the item is already in the order, increment the quantity
                    existingOrderItem.Quantity++;
                }
                else
                {
                    // If the item is not in the order, add a new order item
                    orderItems.Add(new OrderItem { MenuItem = selectedItem, Quantity = 1 });
                }

                // Update the total price
                totalTextBlock.Text = orderItems.Sum(x => x.TotalPrice).ToString("C");
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the order item corresponding to the clicked remove button
            var button = (Button)sender;
            var orderItem = (OrderItem)button.DataContext;

            // Remove the order item from the order items list
            orderItems.Remove(orderItem);

            // Update the total price
            totalTextBlock.Text = orderItems.Sum(x => x.TotalPrice).ToString("C");
        }



    }
    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => MenuItem.Price * Quantity;
    }

}
