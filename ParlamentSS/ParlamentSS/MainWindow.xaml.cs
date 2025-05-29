using ParlamentSS.Pages;
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

namespace ParlamentSS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Обработчик кнопки входа
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Валидация полей
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                PasswordBox.Password.Length == 0)
            {
                ErrorMessage.Text = "Логин и пароль обязательны для заполнения";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            // Здесь должна быть проверка логина/пароля
            // Например, проверка с базой данных или сервисом аутентификации

            // Временная заглушка для демонстрации
            if (UsernameTextBox.Text == "admin" && PasswordBox.Password == "admin")
            {
                ErrorMessage.Visibility = Visibility.Collapsed;

                // Переход к главному окну после успешной авторизации
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                ErrorMessage.Text = "Неверный логин или пароль";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        // Обработчик кнопки регистрации
        private void RegisterLinkButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registerWindow = new RegistrationWindow();
            registerWindow.Show();
            this.Close();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = new RegistrationWindow();
            authWindow.Show();
            this.Close();

        }
    }
}
