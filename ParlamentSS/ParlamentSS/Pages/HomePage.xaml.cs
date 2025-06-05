using ParlamentSS.AppData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace ParlamentSS.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            AppConnect.Model1 = new Entities2();

            List<parties> partie =  AppConnect.Model1.parties.ToList();
            PartiesListView.ItemsSource = partie;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            FindPartie();
        }

        private void PartiesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<parties> products = AppConnect.Model1.parties.ToList();


            PartiesListView.ItemsSource = products;
        }

        parties[] FindPartie()
        {
            var parties = AppConnect.Model1.parties.ToList();
            var productal = parties;

            return parties.ToArray();
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
