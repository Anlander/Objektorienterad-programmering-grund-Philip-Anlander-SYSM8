using Fit_Tracker.Pages.Register;
using Fit_Tracker.Pages.WorkoutsWindow;
using Fit_Tracker.ViewModel;
using System.Windows;

namespace Fit_Tracker
{
    public partial class MainWindow : Window
    {




        string UsernameInput { get; set; }
        string PasswordInput { get; set; }

        public MainWindow()
        {
            UsernameInput = "";
            PasswordInput = "";

            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {

            WorkoutsWindow workOut = new WorkoutsWindow();
            workOut.Show();
            Close();

        }
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            Register register = new Pages.Register.Register();
            register.Show();
            Close();
        }

        private void UserName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UsernameInput = UserName.Text;
        }
    }
}