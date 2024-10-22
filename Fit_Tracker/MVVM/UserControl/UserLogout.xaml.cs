using System.Windows;

namespace Fit_Tracker.MVVM.UserControl
{
    public partial class UserLogout
    {
        public UserLogout()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        // Close the current window and show the main window
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Window.GetWindow(this).Close();
            mainWindow.Show();
        }
        public static readonly DependencyProperty UsernameProperty =
          DependencyProperty.Register("Username", typeof(string), typeof(UserLogout), new PropertyMetadata(string.Empty));

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
    }
}
