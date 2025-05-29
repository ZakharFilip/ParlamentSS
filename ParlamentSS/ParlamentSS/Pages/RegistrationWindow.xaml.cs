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

namespace ParlamentSS.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        // Обработчик для кнопки "Войти" (переход к окну авторизации)
        private void LoginLinkButton_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = new MainWindow();
            authWindow.Show();
            Close();
        }

        // Дополнительно можно добавить обработчик для кнопки регистрации
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь будет логика регистрации
            // Проверка полей, сохранение пользователя и т.д.

            // Пример валидации:
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                PasswordBox.Password.Length == 0 ||
                ConfirmPasswordBox.Password.Length == 0)
            {
                ErrorMessage.Text = "Все поля обязательны для заполнения";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                ErrorMessage.Text = "Пароли не совпадают";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            // Если все проверки пройдены
            ErrorMessage.Visibility = Visibility.Collapsed;

            // Здесь должна быть логика регистрации пользователя
            // После успешной регистрации можно перейти к основному окну
            // MainWindow mainWindow = new MainWindow();
            // mainWindow.Show();
            // this.Close();
        }
    }
}
