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
using WpfApp1zadan.AppData;

namespace WpfApp1zadan.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model1.Authors.Count(x => x.login == txtLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); return;
            }
            try
            {
                Authors userObj = new Authors()
                {
                    login = txtLogin.Text,
                    authorName = txtAuthorName.Text,
                    password = psbPassword.Password
                };
                AppConnect.model1.Authors.Add(userObj);
                AppConnect.model1.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void psbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPassword.Password != psbPasswordPovtor.Password)
            {
                btnCreate.IsEnabled = false;
                psbPassword.Background = Brushes.LightCoral;
                psbPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPassword.Background = Brushes.LightGreen;
                psbPassword.BorderBrush = Brushes.Green;
            }
        }

        private void psbPasswordPovtor_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPassword.Password != psbPasswordPovtor.Password)
            {
                btnCreate.IsEnabled = false;
                psbPassword.Background = Brushes.LightCoral;
                psbPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPassword.Background = Brushes.LightGreen;
                psbPassword.BorderBrush = Brushes.Green;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmMain1.GoBack();
        }
    }
}
