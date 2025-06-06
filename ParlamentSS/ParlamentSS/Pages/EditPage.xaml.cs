using ParlamentSS.AppData;
using ParlamentSS.Class;
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
using System.Xml.Linq;

namespace ParlamentSS.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage()
        {
            
            AppConnect.Model1 = new Entities2();
        }
        public int _id_party;
        public EditPage(int id_party, string _name, string _program, string _info, string _logo)
        {
            InitializeComponent();
            NameTextBox.Text = _name;
            ProgramTextBox.Text = _program;
            InfoTextBox.Text = _info;
            textBoxLogoLonk.Text = _logo;
            _id_party = id_party;
        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                ErrorMessage.Text = "Название партии обязательно для заполнения.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (NameTextBox.Text.Length > 100)
            {
                ErrorMessage.Text = "Название партии не должно превышать 100 символов.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }
            
            var party = AppConnect.Model1.parties.FirstOrDefault(p => p.id_party == _id_party);
            party.name = NameTextBox.Text;
            party.program = ProgramTextBox.Text;
            party.info = InfoTextBox.Text;
            party.logo = textBoxLogoLonk.Text;
            AppConnect.Model1.SaveChanges();

            MessageBox.Show("Партия успешно обновлена!",
                           "Успех",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            NavigationService?.Navigate(homePage);
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
