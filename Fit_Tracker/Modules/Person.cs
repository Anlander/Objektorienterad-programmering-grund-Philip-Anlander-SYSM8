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

        //public abstract bool SignIn(string Username, string Password);
        public abstract void SignIn();
    }


    // Skapa User
    public class User : Person
    {
        public string Country { get; set; }
        public User(string Username, string Password, string Country) : base(Username, Password)
        {
            this.Country = Country;
        }

        //public override bool SignIn(string Username, string Password)
        //{
        //    return true;
        //}   
        public override void SignIn()
        {

        }
    }


    // Admin user får allt som user har.
}
