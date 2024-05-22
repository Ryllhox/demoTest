using demoTest.Pages;
using demoTest.Utilities;
using System.Windows;

namespace demoTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameClass.mainFrame = frameInWindow;
            frameInWindow.Navigate(new LoginPage());
        }

        private void btnHideWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnFullWindow_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Закрытие программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frameInWindow.GoBack();
            }
            catch
            {
                MessageBox.Show("Вы больше не можете возвращаться назад!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}