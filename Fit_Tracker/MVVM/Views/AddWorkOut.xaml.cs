using Fit_Tracker.classes;
using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Fit_Tracker.MVVM.Views
{
    public partial class AddWorkOut : Window
    {
        private string _currentUsername;

        public AddWorkOut(User user)
        {
            InitializeComponent();
            WorkOutViewModel vm = new WorkOutViewModel(user);
            this.DataContext = vm;
            _currentUsername = user.Username;

        }


        private void ButtonCardio_Click(object sender, RoutedEventArgs e)
        {
            // Check if the fields are empty
            if (string.IsNullOrWhiteSpace(Date.Text) ||
                  string.IsNullOrWhiteSpace(CaloriesBurned.Text) ||
                  string.IsNullOrWhiteSpace(Notes.Text) ||
                  string.IsNullOrWhiteSpace(Distance.Text) ||
                  string.IsNullOrWhiteSpace(Duration.Text))
            {
                MessageBox.Show("Please fill in all fields before proceeding.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                CardioWorkout workout = new CardioWorkout(
                    date: Date.DisplayDate,
                    type: Type.Text,
                    caloriesBurned: Convert.ToInt32(CaloriesBurned.Text),
                    notes: Notes.Text,
                    distance: Convert.ToInt32(Distance.Text),
                    duration: TimeSpan.FromMinutes(Convert.ToInt32(Duration.Text)));
                // Use Usermanager to add the workout to the current user

                Usermanager.AddWorkoutToUser(_currentUsername, workout);
                this.Close();
            }

        }

        private void ButtonStrength_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Strength_Type.Text) ||
                   string.IsNullOrWhiteSpace(Strength_CaloriesBurned.Text) ||
                   string.IsNullOrWhiteSpace(Strength_Notes.Text) ||
                   string.IsNullOrWhiteSpace(Strength_Repetitations.Text) ||
                   string.IsNullOrWhiteSpace(Strength_Duration.Text))
            {
                MessageBox.Show("Please fill in all fields before proceeding.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                StrengthWorkout workout = new StrengthWorkout(
                    date: Strength_Date.DisplayDate,
                    type: Strength_Type.Text,
                    caloriesBurned: Convert.ToInt32(Strength_CaloriesBurned.Text),
                    notes: Strength_Notes.Text,
                    Repetitations: Convert.ToInt32(Strength_Repetitations.Text),
                    duration: TimeSpan.FromMinutes(Convert.ToInt32(Strength_Duration.Text)));
                // Use Usermanager to add the workout to the current user

                Usermanager.AddWorkoutToUser(_currentUsername, workout);
                this.Close();
            }

        }


        // Show or hide the correct workout type
        private void OptionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the specific item that was selected

            ComboBoxItem comboBoxItem = (ComboBoxItem)OptionsComboBox.SelectedItem;
            // Get Tag Value
            string workoutType = comboBoxItem.Tag.ToString();

            // Show or hide depending on the workout type
            if (workoutType == "Cardio")
            {
                CardioWorkOut.Visibility = Visibility.Visible;
                StrengthWorkout.Visibility = Visibility.Collapsed;
            }
            else if (workoutType == "Strength")
            {
                CardioWorkOut.Visibility = Visibility.Collapsed;
                StrengthWorkout.Visibility = Visibility.Visible;
            }
        }
    }
}
