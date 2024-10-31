using Fit_Tracker.Modules;
using System.Windows;
using System.Windows.Controls;

namespace Fit_Tracker.Pages.WorkoutDetailsWindow
{

    public partial class WorkoutDetailsWindow : Window
    {
        private Workout selectedWorkout;
        public WorkoutDetailsWindow(Workout selectedWorkout)
        {
            InitializeComponent();


            this.selectedWorkout = selectedWorkout;
            DataContext = selectedWorkout;

            workOutType.Text = selectedWorkout is CardioWorkout ? "Distance" : "Repetitations";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // function for EnableInputFields
        private void EnableInputFields(bool show)
        {
            try
            {
                date.IsEnabled = show;
                type.IsEnabled = show;
                duration.IsEnabled = show;
                caloriesBurned.IsEnabled = show;
                notes.IsEnabled = show;
                if (selectedWorkout is CardioWorkout)
                {
                    repetitations.Visibility = Visibility.Collapsed;
                    distance.IsEnabled = show;
                }
                else if (selectedWorkout is StrengthWorkout)
                {
                    distance.Visibility = Visibility.Collapsed;
                    repetitations.IsEnabled = show;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // function for SetBorderThickness
        private void SetBorderThickness(int thickness)
        {
            type.BorderThickness = new Thickness(thickness);
            date.BorderThickness = new Thickness(thickness);
            duration.BorderThickness = new Thickness(thickness);
            caloriesBurned.BorderThickness = new Thickness(thickness);
            notes.BorderThickness = new Thickness(thickness);
            repetitations.BorderThickness = new Thickness(thickness);
            distance.BorderThickness = new Thickness(thickness);
        }

        // Edit button click event
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EnableInputFields(true);
            SetBorderThickness(2);
            edit.Visibility = Visibility.Collapsed;
            save.Visibility = Visibility.Visible;

        }

        // Save button click event
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // List of all input fields to validate
            var inputFields = new List<TextBox> { date, type, duration, caloriesBurned, notes };

            // Add specific fields based on workout type
            if (selectedWorkout is CardioWorkout)
            {
                inputFields.Add(distance);
            }
            else if (selectedWorkout is StrengthWorkout)
            {
                inputFields.Add(repetitations);
            }

            // Check if any field is empty
            foreach (var field in inputFields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    MessageBox.Show("Please fill in all fields before saving.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            // if all fields are filled, save the changes
            save.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Visible;
            EnableInputFields(false);
            SetBorderThickness(0);
            this.Close();
        }

    }
}
