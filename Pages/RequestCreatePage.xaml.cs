using demoTest.Domain;
using demoTest.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace demoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestCreatePage.xaml
    /// </summary>
    public partial class RequestCreatePage : Page
    {
        ApplicationDbContext context = new();
        public RequestCreatePage()
        {
            InitializeComponent();
            var products = context.Products.ToList();
            cbProduct.ItemsSource = products;
            cbProduct.DisplayMemberPath = "Name";
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            if (cbProduct.SelectedIndex==-1||tbProblem.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    var status = context.Statuses.FirstOrDefault(s=>s.Name=="Новая заявка");

                    var user = context.Users.FirstOrDefault(u=>u.Id==UserClass.UserNow.Id);

                    Request request = new()
                    {
                        Product = (Product)cbProduct.SelectedItem,
                        Problem = tbProblem.Text,
                        Status = status,
                        User = user,
                        DateAdd = DateTime.Now
                    };

                    context.Add(request);
                    context.SaveChanges();
                    MessageBox.Show("Заявка успешно отправлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    FrameClass.mainFrame.Navigate(new UserPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
