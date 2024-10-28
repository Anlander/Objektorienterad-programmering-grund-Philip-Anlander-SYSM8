using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.MVVM;
using System.Collections.ObjectModel;

namespace Fit_Tracker.ViewModel
{
    public class WorkOutViewModel : ViewModelBase
    {
        public ObservableCollection<Workout> Workouts { get; set; }

        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public RelayCommand DeleteCommand => new RelayCommand(execute => RemoveItem(), canExecute => selectedWorkout != null);

        public WorkOutViewModel(User currentUser)
        {
            Workouts = currentUser.Workouts;
            CurrentUser = currentUser;
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

        private void RemoveItem()
        {
            Workouts.Remove(SelectedWorkout);
        }
    }
}
