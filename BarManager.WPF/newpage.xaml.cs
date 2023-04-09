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
    /// Interaction logic for newpage.xaml
    /// </summary>
    public partial class newpage : Page
    {
       
        public newpage()
        {
            InitializeComponent();
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Datagridtest.Items.Add(new Product()
            {
                id = 1,
                name = "Test",
            });

            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Datagridtest.Items.Add(new Product()
            {
                id = 1,
                name = "Test",
            });
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Datagridtest.SelectedItem.ToString());
        }
    }
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return $"id:{id} , name:{name}";
        }
    }
}
