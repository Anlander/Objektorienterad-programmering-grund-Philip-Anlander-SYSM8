using Fit_Tracker.Classes;
using System.Windows;

namespace Fit_Tracker.MVVM.Views
{

    public partial class UserDetails : Window
    {

        public UserDetails(User user)
        {
            InitializeComponent();
            this.DataContext = user;
        }

        private void EnableEdit(bool show)
        {
            username.IsEnabled = show;
            password.IsEnabled = show;
            countryComboBox.IsEnabled = show;
            cfmPassword.IsEnabled = show;
            Save.IsEnabled = show;
        }


        private void EditDetails_Click(object sender, RoutedEventArgs e)
        {
            EnableEdit(true);
        }
        private void SaveDetails_Click(object sender, RoutedEventArgs e)
        {
            if (password.Text != cfmPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            password.Clear();
            cfmPassword.Clear();
            EnableEdit(false);
        }
    }
}
