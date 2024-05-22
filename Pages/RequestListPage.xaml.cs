using demoTest.Domain;
using demoTest.Utilities;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace demoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestListPage.xaml
    /// </summary>
    public partial class RequestListPage : Page
    {
        ApplicationDbContext context = new();
        public RequestListPage()
        {
            InitializeComponent();
            byte[] qrCodeImage = GenerateQRCode("vk.com");
            using ( MemoryStream memStream = new(qrCodeImage))
            {
                BitmapImage bitmap = new();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource= memStream;
                bitmap.EndInit();
                imgQR.Source = bitmap;
            }
            LoadData();
        }

        void LoadData()
        {
            var user = context.Users.FirstOrDefault(u => u.Id == UserClass.UserNow.Id);
            var request = context.Requests.Include(r=>r.Product).Include(r=>r.Status).Where(r => r.User == user).ToList();
            dtGridListReq.ItemsSource = request;
        }

        static byte[] GenerateQRCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
