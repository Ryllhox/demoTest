using demoTest.Utilities;
using System.Windows;
using System.Windows.Controls;

namespace demoTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void btnRequestList_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new RequestListPage());
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new RequestCreatePage());
        }
    }
}
