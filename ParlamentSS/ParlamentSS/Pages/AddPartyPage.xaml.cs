using ParlamentSS.AppData;
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

namespace ParlamentSS.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPartyPage.xaml
    /// </summary>
    public partial class AddPartyPage : Page
    {
        public AddPartyPage()
        {
            InitializeComponent();
            AppConnect.Model1 = new Entities2();
        }

        private void CreatePartyButton_Click(object sender, RoutedEventArgs e)
        {
            // Сброс сообщения об ошибке
            ErrorMessage.Visibility = Visibility.Collapsed;
            ErrorMessage.Text = "";

            // Сбор данных
            string name = NameTextBox.Text.Trim();
            string program = ProgramTextBox.Text.Trim();
            string info = InfoTextBox.Text.Trim();
            DateTime? foundationDate = FoundationDatePicker.SelectedDate;
            string logotipe = textBlockLogo.Text;

            // Валидация
            if (string.IsNullOrEmpty(name))
            {
                ErrorMessage.Text = "Название партии обязательно для заполнения.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (name.Length > 100)
            {
                ErrorMessage.Text = "Название партии не должно превышать 100 символов.";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            try
            {
                // Проверка уникальности названия (если требуется)
                if (AppConnect.Model1.parties.Any(p => p.name == name))
                {
                    ErrorMessage.Text = "Партия с таким названием уже существует.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return;
                }

                // Создание новой партии
                parties newParty = new parties
                {
                    name = name,
                    program = string.IsNullOrEmpty(program) ? null : program,
                    info = string.IsNullOrEmpty(info) ? null : info,
                    foundation_date = foundationDate,
                    logo = logotipe
                };

                // Добавление в базу данных
                AppConnect.Model1.parties.Add(newParty);
                AppConnect.Model1.SaveChanges();

                // Успешное создание
                MessageBox.Show("Партия успешно создана!",
                               "Успех",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);

                // Очистка полей
                NameTextBox.Text = "";
                ProgramTextBox.Text = "";
                InfoTextBox.Text = "";
                FoundationDatePicker.SelectedDate = null;
               // _logoData = null;
              
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = $"Ошибка при создании партии: {ex.Message}";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
