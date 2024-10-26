using Fit_Tracker.classes;
using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using Fit_Tracker.MVVM;
using System.Collections.ObjectModel;

namespace Fit_Tracker.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }
        private Usermanager userManager;
        private Person selectedItem;
        private User _loggedInUser;

        public MainWindowViewModel()
        {
            userManager = new Usermanager();
            Users = new ObservableCollection<User>(Usermanager.GetUsers());
        }

        public void AddUser(string username, string password, string country)
        {
            userManager.AddUser(username, password, country);
            Users.Add(new User(username, password, country));
        }

        public void AddWorkoutToUser(string username, Workout workout)
        {
            Usermanager.AddWorkoutToUser(username, workout);
            var user = Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Workouts.Add(workout);
            }
        }

        public bool UserExists(string username)
        {
            return Users.Any(u => u.Username == username);
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

        public User LoggedInUser
        {
            get => _loggedInUser;
            set
            {
                _loggedInUser = value;
                OnPropertyChanged();
            }
        }

        // when loggout is pressed, clear the data so it wont copy in workouts when you logg in.
        public void Logout()
        {
            LoggedInUser = null;
            Usermanager.ClearUserData();
        }
    }
}
