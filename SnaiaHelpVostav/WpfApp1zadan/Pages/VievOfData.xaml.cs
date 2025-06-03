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
using WpfApp1zadan.AppData;

namespace WpfApp1zadan.Pages
{
    /// <summary>
    /// Логика взаимодействия для VievOfData.xaml
    /// </summary>
    public partial class VievOfData : Page
    {
        public VievOfData()
        {
            InitializeComponent();
            List<Recipes> products = AppConnect.model1.Recipes.ToList();

         
            listVievMain.ItemsSource = products;
        }

        private void listVievMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Recipes> products = AppConnect.model1.Recipes.ToList();


            listVievMain.ItemsSource = products;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            FindRecipe();
        }

        Recipes[] FindRecipe()
        {
            var recipes = AppConnect.model1.Recipes.ToList();
            var productal = recipes;

            return recipes.ToArray();
        }
    }
}
