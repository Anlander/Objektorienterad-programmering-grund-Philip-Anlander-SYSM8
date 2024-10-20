using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.MVVM;
using System.Collections.ObjectModel;

namespace Fit_Tracker.ViewModel
{
    public class WorkOutViewModel : ViewModelBase
    {
        public ObservableCollection<Workout> Workouts { get; set; }
        public WorkOutViewModel(User currentUser)
        {

            Workouts = currentUser.Workouts;
        }

        private CardioWorkout selectedWorkout;

        public CardioWorkout SelectedWorkout
        {
            get { return selectedWorkout; }
            set { selectedWorkout = value; }
        }



    }
}