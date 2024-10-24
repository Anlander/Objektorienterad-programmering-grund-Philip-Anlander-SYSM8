﻿using Fit_Tracker.classes;
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
            this.DataContext = vm;

            username.Text = $"Welcome, {currentUser.Username}";
        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            if (WorkoutList.SelectedItem is CardioWorkout selectedCardioWorkout)
            {
                WorkoutDetailsWindow.WorkoutDetailsWindow details = new WorkoutDetailsWindow.WorkoutDetailsWindow(selectedCardioWorkout);
                details.ShowDialog();
            }
            else if (WorkoutList.SelectedItem is StrengthWorkout selectedStrengthWorkout)
            {
                WorkoutDetailsWindow.WorkoutDetailsWindow details = new WorkoutDetailsWindow.WorkoutDetailsWindow(selectedStrengthWorkout);
                details.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There is no selected item");
            }
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
                // if user haven't selected anything, show this messagebox.
                MessageBox.Show("Please select a workout to remove.");
            }
        }

        private void Add_Workout(object sender, RoutedEventArgs e)
        {
            chooseWorkout.Visibility = Visibility.Visible;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Usermanager.ClearUserData();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
