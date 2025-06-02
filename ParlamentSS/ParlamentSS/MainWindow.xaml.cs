using ParlamentSS.AppData;
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
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //кнопки входа
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
            /**/
            try
            {
                var userObj = AppConnect.Model1.users.FirstOrDefault(x => x.email == UsernameTextBox.Text && x.password == PasswordBox.Password);
                if (userObj == null)
                {
                    labelError.Content = "Неверная почта или пароль";
                }
                else
                {
                    switch (userObj.id_role)
                    {
                        case 1:
                            ToMainVindowPerehod();
                            break;

                        case 2:
                            ToMainVindowPerehod();
                            break;
                        case 3:
                            ToMainVindowPerehod();
                            break;
                        case 4:
                            ToMainVindowPerehod();
                            break;

                        default: MessageBox.Show("ERROR", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning); break;
                    }
                }
            }
            
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void ToMainVindowPerehod()
        {
            // Переход к главному окну после успешной авторизации
            ViewMainWindow ToMainWindow = new ViewMainWindow();
            ToMainWindow.Show();
            this.Close();
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

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
