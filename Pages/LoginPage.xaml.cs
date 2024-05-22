using demoTest.Domain;
using demoTest.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace demoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ApplicationDbContext context = new();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new RegisterPage());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.IsNullOrEmpty() || pbPassword.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var user = context.Users.Include(u=>u.Role).FirstOrDefault(u => u.Login == tbLogin.Text);
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (user.Login != tbLogin.Text || user.Password != pbPassword.Password)
                    {
                        MessageBox.Show("Неверный логин или пароль", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        try
                        {
                            UserClass.UserNow=user;
                            MessageBox.Show("Авторизация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            var roleUser = context.Roles.FirstOrDefault(r => r.Id == user.Role.Id);
                            if (roleUser.Id == 4)
                            {
                                FrameClass.mainFrame.Navigate(new AdminPage());
                            }
                            else
                            {
                                FrameClass.mainFrame.Navigate(new UserPage());
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
