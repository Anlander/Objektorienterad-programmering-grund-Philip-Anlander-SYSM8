using Fit_Tracker.Modules;
using System.Collections.ObjectModel;

namespace Fit_Tracker.Classes
{


    //Skapa en abstract person
    public abstract class Person
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Person(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public abstract bool SignIn();
    }


    // Skapa User
    public class User : Person
    {
        public ObservableCollection<Workout> Workouts { get; set; }
        public string Country { get; set; }
        public User(string Username, string Password, string Country) : base(Username, Password)
        {
            this.Country = Country;
            Workouts = new ObservableCollection<Workout>();
        }

        public override bool SignIn()
        {
            return true;
        }
    }


    // Admin user får allt som user har.
}
