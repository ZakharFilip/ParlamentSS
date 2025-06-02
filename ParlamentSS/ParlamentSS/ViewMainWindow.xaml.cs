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
using System.Windows.Shapes;

namespace ParlamentSS
{
    /// <summary>
    /// Логика взаимодействия для ViewMainWindow.xaml
    /// </summary>
    public partial class ViewMainWindow : Window
    {
        public ViewMainWindow()
        {
            InitializeComponent();
            // Загрузка стартовой страницы
            MainFrame.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }

        private void NavigateToHomePage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }

        private void NavigateToProfilePage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative)); //ИЗМЕНИТЬ АДРЕСС
        }

        private void NavigateToSettingsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/SettingsPage.xaml", UriKind.Relative));//ИЗМЕНИТТЬ АДРЕСС
        }

        private void NavigateToParty(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/PartyPage.xaml", UriKind.Relative));
        }
        private void NavigateToPartyMembers(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/PartyMembersPage.xaml", UriKind.Relative));
        }
        private void NavigateToParlament(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/ParlamentPage.xaml", UriKind.Relative));
        }





    }
}
