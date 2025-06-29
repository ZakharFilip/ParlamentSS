using ParlamentSS.AppData;
using ParlamentSS.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
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
        public ObservableCollection<parties> Parties { get; set; }
        public HomePage()
        {
            InitializeComponent();
            AppConnect.Model1 = new Entities2();

            List<parties> partie =  AppConnect.Model1.parties.ToList();
            PartiesListView.ItemsSource = partie;

            Parties = new ObservableCollection<parties>();
            DataContext = this;
            LoadParties();

        }
        
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdatePartiesList();
        }
        
        private void PartiesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (PartiesListView.SelectedItem is parties selectedParty && AppConnect.currentUser.id_role != 3)
            {
                EditPage editPage = new EditPage(selectedParty.id_party, selectedParty.name, selectedParty.program, selectedParty.info, selectedParty.logo);
                NavigationService?.Navigate(editPage);
            }
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePartiesList();
        }

        private void UpdatePartiesList()
        {
            string searchText = textBoxSearch.Text.Trim().ToLower();
            try
            {
                var query = AppConnect.Model1.parties.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(p =>
                        (p.name != null && p.name.ToLower().Contains(searchText)) ||
                        (p.program != null && p.program.ToLower().Contains(searchText)) ||
                        (p.info != null && p.info.ToLower().Contains(searchText)));
                }

                var filteredParties = query.ToList();
                Parties.Clear();
                foreach (var party in filteredParties)
                {
                    Parties.Add(party);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadParties()
        {
            try
            {
                var parties = AppConnect.Model1.parties.ToList();
                Parties.Clear();
                foreach (var party in parties)
                {
                    Parties.Add(party);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void buttonQrCode_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonQrCode_Click_1(object sender, RoutedEventArgs e)
        {
            OutDorPage outDorPage = new OutDorPage();
            NavigationService?.Navigate(outDorPage);
        }
    }
}
