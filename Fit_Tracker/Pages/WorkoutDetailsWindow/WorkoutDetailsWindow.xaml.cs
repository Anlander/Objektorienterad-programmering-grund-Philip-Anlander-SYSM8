using Fit_Tracker.Modules;
using System.Windows;

namespace Fit_Tracker.Pages.WorkoutDetailsWindow
{
    /// <summary>
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        public WorkoutDetailsWindow(Workout selectedWorkout)
        {
            InitializeComponent();
            DataContext = selectedWorkout;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
