using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.ViewModel;
using System.Windows;

namespace Fit_Tracker.Pages.WorkoutsWindow
{

    public partial class WorkoutsWindow : Window
    {

        public WorkoutsWindow(User currentUser)
        {

            InitializeComponent();
            WorkOutViewModel vm = new WorkOutViewModel(currentUser);
            DataContext = vm;

        }

        private void details_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            // check if something is selected
            if (WorkoutList.SelectedItem is Workout selectedWorkout)
            {
                var res = MessageBox.Show($"You have selected {selectedWorkout.Type} " +
                    $"with Date: {selectedWorkout.Date}", "You sure you want to remove?",
                    MessageBoxButton.YesNo);

                if (res == MessageBoxResult.Yes)
                {
                    var viewModel = (WorkOutViewModel)DataContext;
                    viewModel.Workouts.Remove(selectedWorkout);
                }
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.");
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
