using Fit_Tracker.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Fit_Tracker.MVVM.Views
{

    public partial class UserDetails : Window
    {

        public UserDetails(User user)
        {
            InitializeComponent();
            this.DataContext = user;

        }


        // Enable or disable the edit mode
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

        // Cancel the changes
        private void CancelDetails_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)this.DataContext;
            username.Text = user.Username;
            this.Close();
        }



        // Save the new changes & check validation
        private void SaveDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (password.Text != cfmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match");
                    return;
                }
                if (password.Text.Length <= 5)
                {
                    MessageBox.Show("Passwords needs to be at least 6");
                    return;
                }

                username.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
                countryComboBox.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
                password.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

                Save.IsEnabled = false;

                EnableEdit(false);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
