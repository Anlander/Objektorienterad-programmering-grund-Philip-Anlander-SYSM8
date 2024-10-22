using Fit_Tracker.Classes;
using Fit_Tracker.Modules;
using System.Collections.ObjectModel;

namespace Fit_Tracker.classes
{
    public class Usermanager
    {
        public static ObservableCollection<User> _UserDataBase = new ObservableCollection<User>() {
                new User("username", "password", "Sweden"),
                new User("admin", "password", "Sweden"),
                new User("philip", "123", "Sweden")
            };

        public static ObservableCollection<User> GetUsers()
        {
            return _UserDataBase;
        }

        public static void AddUser(User user)
        {
            _UserDataBase.Add(user);
            AddAllWorkoutsToAdmin();
        }

        public Usermanager()
        {
            AddSampleData();
            AddAllWorkoutsToAdmin();
        }


        // AddUser för RegisterUser
        public void AddUser(string username, string password, string country)
        {
            var newUser = new User(username, password, country);
            AddUser(newUser);
        }


        // Adderar Workout till user
        public static void AddWorkoutToUser(string username, Workout workout)
        {
            User user = _UserDataBase.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Workouts.Add(workout);
                AddWorkoutToAdmin(workout);
            }
        }


        // Simpel sample data från användaren som finns i databasen
        private void AddSampleData()
        {
            var sampleUser1 = _UserDataBase.FirstOrDefault(u => u.Username == "username");
            var sampleUser2 = _UserDataBase.FirstOrDefault(u => u.Username == "philip");

            if (sampleUser1 != null)
            {
                sampleUser1.Workouts.Add(new CardioWorkout(date: DateTime.Now,
                    type: "Running",
                    duration: TimeSpan.FromMinutes(30),
                    caloriesBurned: 2000,
                    distance: 200,
                    notes: "Went well!"));

                sampleUser1.Workouts.Add(new StrengthWorkout(date: DateTime.Now,
                   type: "Weight Lift",
                   duration: TimeSpan.FromMinutes(30),
                   caloriesBurned: 200,
                   Repetitations: 20,
                   notes: "Went well!"));
            }

            if (sampleUser2 != null)
            {
                sampleUser2.Workouts.Add(new CardioWorkout(
                    date: DateTime.Now, type: "Cardio",
                    caloriesBurned: 5000,
                    distance: 500,
                    duration: TimeSpan.FromMinutes(30),
                    notes: "No notes"
                ));
            }
        }


        // Adds all workouts to admin
        private static void AddAllWorkoutsToAdmin()
        {
            var adminUser = _UserDataBase.FirstOrDefault(u => u.Username == "admin");
            if (adminUser != null)
            {
                adminUser.Workouts.Clear(); // Clear existing workouts to avoid duplicates
                foreach (var user in _UserDataBase)
                {
                    if (user.Username != "admin")
                    {
                        foreach (var workout in user.Workouts)
                        {
                            adminUser.Workouts.Add(workout);
                        }
                    }
                }
            }
        }

        private static void AddWorkoutToAdmin(Workout workout)
        {
            var adminUser = _UserDataBase.FirstOrDefault(u => u.Username == "admin");
            if (adminUser != null)
            {
                adminUser.Workouts.Add(workout);
            }
        }
    }
}
