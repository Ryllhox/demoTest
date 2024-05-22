using demoTest.Domain;
using demoTest.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace demoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        ApplicationDbContext context = new();
        public RegisterPage()
        {
            InitializeComponent();
            var roles = context.Roles;
            cbRoles.ItemsSource = roles.ToList();
            cbRoles.DisplayMemberPath = "Name";
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

            if (tbSurname.Text.IsNullOrEmpty() || tbName.Text.IsNullOrEmpty() || tbPhone.Text.IsNullOrEmpty() ||
                tbLogin.Text.IsNullOrEmpty() || pbPassword.Password.IsNullOrEmpty() || pbPassCheck.Password.IsNullOrEmpty() ||
                cbRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (pbPassword.Password != pbPassCheck.Password)
                {
                    MessageBox.Show("Пароли не совпадают!", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var user = context.Users.FirstOrDefault(u => u.Login == tbLogin.Text);
                    if (user != null)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Неудачно!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        try
                        {
                            User User = new()
                            {
                                Surname = tbSurname.Text,
                                Name = tbName.Text,
                                Patronymic = tbPatronymic.Text,
                                Phone = int.Parse(tbPhone.Text),
                                Login = tbLogin.Text,
                                Password = pbPassword.Password,
                                Role = (Role)cbRoles.SelectedItem
                            };

                            context.Users.Add(User);
                            context.SaveChanges();
                            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            FrameClass.mainFrame.Navigate(new LoginPage());
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
