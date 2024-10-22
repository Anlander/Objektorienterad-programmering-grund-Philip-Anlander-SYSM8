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
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string country = countryBox.Text;

            mainWindowViewModel.AddUser(username, password, country);
            this.Close();

        }
    }
}
