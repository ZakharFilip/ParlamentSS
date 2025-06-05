using ParlamentSS.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    // <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            AppConnect.Model1 = new Entities2(); // Инициализация контекста
        }

        private void LoginLinkButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу авторизации
            MainWindow ToMainWindow = new MainWindow();
            ToMainWindow.Show();
            this.Close();

        }

        private void RegisterButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Сбор данных из полей
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string nickname = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string confirmPassword = ConfirmPasswordBox.Password.Trim();




            // Валидация данных
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nickname) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ErrorMessage.Text = "Все поля должны быть заполнены.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (password != confirmPassword)
            {
                ErrorMessage.Text = "Пароли не совпадают.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            // Проверка формата email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                ErrorMessage.Text = "Некорректный формат электронной почты.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            // Проверка длины полей (соответствие ограничениям базы данных)
            if (firstName.Length > 50 || lastName.Length > 50 || email.Length > 50 || nickname.Length > 50)
            {
                ErrorMessage.Text = "Поля не должны превышать 50 символов.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (password.Length > 50)
            {
                ErrorMessage.Text = "Пароль не должен превышать 50 символов.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            try
            {

                // Проверка уникальности email и никнейма
                if (AppConnect.Model1.users.Count(x => x.email == email) > 0) // Замените User на правильное имя сущности
                {
                    ErrorMessage.Text = "Этот email уже зарегистрирован.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return;
                }

                if (AppConnect.Model1.users.Count(x => x.nickname == nickname) > 0) // Замените User на правильное имя сущности
                {
                    ErrorMessage.Text = "Этот никнейм уже занят.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return;
                }

                users odj = new users()
                {
                    first_name = firstName,
                    last_name = lastName,
                    email = email,
                    password = password,
                    nickname = nickname,
                    id_role = 3
                };

                AppConnect.Model1.users.Add(odj);
                AppConnect.Model1.SaveChanges();

                // Успешная регистрация
                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

               
                // Переход на страницу авторизации
                MainWindow ToMainWindow = new MainWindow();
                ToMainWindow.Show();
                this.Close();

                
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = $"Ошибка при регистрации: {ex.Message}";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
