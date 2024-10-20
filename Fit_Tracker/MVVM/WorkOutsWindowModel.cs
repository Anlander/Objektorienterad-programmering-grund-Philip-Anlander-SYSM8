using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using System.Collections.ObjectModel;

namespace Fit_Tracker.MVVM
{
    public class WorkOutsWindowModel : ViewModelBase
    {
        public ObservableCollection<Workout> UserWorkouts { get; set; }

        public WorkOutsWindowModel(User currentUser)
        {
            UserWorkouts = currentUser.Workouts;
        }
        public void AddCardioWorkout(DateTime date, string type, TimeSpan duration,
            int caloriesBurned, string notes, int distance)
        {
            var cardioWorkout = new CardioWorkout(date, type, duration, caloriesBurned, notes, distance);
            UserWorkouts.Add(cardioWorkout);
        }

        public void AddStrengthWorkout(DateTime date, string type, TimeSpan duration,
            int caloriesBurned, string notes, int distance)
        {
            var strengthWorkout = new CardioWorkout(date, type, duration, caloriesBurned, notes, distance);
            UserWorkouts.Add(strengthWorkout);
        }
    }
}
