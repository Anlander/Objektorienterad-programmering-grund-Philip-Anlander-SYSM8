using Fit_Tracker.ViewModel;
using System.Windows;

namespace Fit_Tracker.MVVM.Views
{
    public partial class Register : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        public Register(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            this.mainWindowViewModel = mainWindowViewModel;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Register the user & check validation
            try
            {
                string username = usernameBox.Text;
                string password = passwordBox.Text;
                string country = countryBox.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(country))
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }
                else if (password.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long");
                    return;
                }
                else if (mainWindowViewModel.UserExists(username))
                {
                    MessageBox.Show("Username already exists");
                    return;
                }

                mainWindowViewModel.AddUser(username, password, country);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }

            // Handle the exception
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
