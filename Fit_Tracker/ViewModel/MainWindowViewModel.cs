using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.MVVM;
using System.Collections.ObjectModel;

namespace Fit_Tracker.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }

        private Person selectedItem;

        public MainWindowViewModel()
        {
            Users = new ObservableCollection<User>();


            // First User for testing if both workout appear.
            var sampleUser1 = new User("username", "password", "Sweden");

            sampleUser1.Workouts.Add(new CardioWorkout(date: DateTime.Now,
                type: "Running",
                duration: TimeSpan.FromMinutes(30),
                caloriesBurned: 200,
                distance: 5,
                notes: "Went well!"));

            sampleUser1.Workouts.Add(new StrengthWorkout(date: DateTime.Now,
               type: "Weight Lift",
               duration: TimeSpan.FromMinutes(30),
               caloriesBurned: 200,
               Repetitations: 5,
               notes: "Went well!"));

            var sampleUser2 = new User("philip", "123", "Sweden");
            sampleUser2.Workouts.Add(new CardioWorkout(
                date: DateTime.Now, type: "Cardio",
                caloriesBurned: 200,
                distance: 5,
                duration: TimeSpan.FromMinutes(30),
                notes: "No notes"
             ));




            Users.Add(sampleUser1);
            Users.Add(sampleUser2);

        }

        public Person SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }

        }

    }
}
