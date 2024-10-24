using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.MVVM;
using System.Collections.ObjectModel;


namespace Fit_Tracker.ViewModel
{
    public class WorkOutViewModel : ViewModelBase
    {
        public ObservableCollection<Workout> Workouts { get; set; }
        public RelayCommand AddCardio => new RelayCommand(execute => AddCardioWorkout());
        public RelayCommand AddStrength => new RelayCommand(execute => AddStrengthWorkout());
        public RelayCommand DeleteCommand => new RelayCommand(execute => RemoveItem(), canExecute => selectedWorkout != null);


        public WorkOutViewModel(User currentUser)
        {
            Workouts = currentUser.Workouts;
        }


        private Workout selectedWorkout;
        public Workout SelectedWorkout
        {
            get { return selectedWorkout; }
            set
            {
                selectedWorkout = value;
                OnPropertyChanged(nameof(SelectedWorkout));
            }
        }


        private void AddCardioWorkout()
        {
            Workouts.Add(new CardioWorkout(date: DateTime.Now, type: "Cardio Workout",
                duration: TimeSpan.FromMinutes(30), caloriesBurned: 0, notes: "No notes", distance: 0));
        }
        private void AddStrengthWorkout()
        {
            Workouts.Add(new StrengthWorkout(date: DateTime.Now, type: "Strength Workout",
                duration: TimeSpan.FromMinutes(30), caloriesBurned: 0, notes: "No notes", Repetitations: 0));
        }

        private void RemoveItem()
        {
            Workouts.Remove(SelectedWorkout);
        }
    }
}
