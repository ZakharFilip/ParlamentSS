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

using QRCoder;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace ParlamentSS.Pages
{
    /// <summary>
    /// Логика взаимодействия для OutDorPage.xaml
    /// </summary>
    public partial class OutDorPage : Page
    {
        public OutDorPage()
        {
            InitializeComponent();
            GenerateGitHubQR();
        }
        private void GenerateGitHubQR()
        {
            //string SiteUrl = "http://147.45.75.47:7777/filippovzakhar.ru/ParlamentSS/";
            string MoneyUrl = "https://www.tbank.ru/cf/SDclugxpyO";

            // Создаём генератор QR-кода
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Указываем данные (URL GitHub) и уровень коррекции ошибок (ECCLevel.Q - средний)
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(MoneyUrl, QRCodeGenerator.ECCLevel.Q);

            // Создаём изображение QR-кода в виде Bitmap
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);

            // Получаем массив байтов изображения (20 - размер пикселя)
            byte[] qrCodeBytes = qrCode.GetGraphic(20);

            // Конвертируем массив байтов в BitmapImage для WPF
            using (MemoryStream ms = new MemoryStream(qrCodeBytes))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                // Отображаем QR-код в элементе Image
                QRImage.Source = bitmapImage;
            }
        }
    }
}
