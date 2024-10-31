using Fit_Tracker.Classes;
using Fit_Tracker.MVVM.Views;
using Fit_Tracker.Pages.WorkoutsWindow;
using Fit_Tracker.ViewModel;
using System.Windows;

namespace Fit_Tracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UserName.Text;
                string password = PassWord.Text;
                var viewModel = (MainWindowViewModel)DataContext;

                // Check if user exist.
                User userExist = viewModel.Users.FirstOrDefault(userU => userU.Username == username && userU.Password == password);

                if (userExist != null)
                {
                    WorkoutsWindow workOut = new WorkoutsWindow(userExist);
                    workOut.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Please fill in correct information", "User doesn't exist or wrong info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Register Window
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var viewModel = (MainWindowViewModel)DataContext;
                Register register = new Register(viewModel);
                register.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
