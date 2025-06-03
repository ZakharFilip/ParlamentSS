using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void butAutorize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model1.Authors.FirstOrDefault(x => x.login == txtLogin.Text && x.password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользолвателя нет!", "Ошибуа при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.idAuthors)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.authorName + "!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); 
                            NavigationService.Navigate(new VievOfData());
                            break;
                        default:
                            MessageBox.Show("Здравствуйте, Ученик " + userObj.authorName + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); 
                            NavigationService.Navigate(new VievOfData());
                            break;
                        //default: MessageBox.Show("Данные не обнарyжены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning); break;
                    }
                    }
                    }catch (Exception Ex) {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void buttonToPracticeWorks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageForPracticeWorks());
        }
    }
}
