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
using ParlamentSS.AppData;

namespace ParlamentSS.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            

            AppData.AppConnect.Model1 = new AppData.Entities2();
            List<users> itemlog = AppConnect.Model1.users.ToList();
            listItemLog.ItemsSource = itemlog;
        }

       
        private void listItemLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listItemLog.SelectedItem is users selectedUser)
            {
                var usak = AppConnect.Model1.users.FirstOrDefault(p => p.id_user == selectedUser.id_user);

                if (selectedUser.block == 0)
                {
                    usak.block = 1;
                    AppConnect.Model1.SaveChanges();

                    MessageBox.Show("Пользак ЗАБЛОЧЕН!",
                                   "Успех",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);
                }
                else {
                    usak.block = 0;
                    AppConnect.Model1.SaveChanges();

                    MessageBox.Show("Пользак Разблокирован!",
                                   "Успех",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Information);
                }

                AppData.AppConnect.Model1 = new AppData.Entities2();
                List<users> itemlog = AppConnect.Model1.users.ToList();
                listItemLog.ItemsSource = itemlog;
            }
        }
    }
}
