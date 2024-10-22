namespace Fit_Tracker.Modules
{
    public abstract class Workout
    {
        // Egenskaper
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }

        // Abstrakt som måste implementeras i subklasserna


        public abstract int CalculateCalobriesBurned();


        // Konstruktor
        public Workout(DateTime date, string type, TimeSpan duration, int caloriesBurned, string notes)
        {
            Date = date;
            Type = type;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
            Notes = notes;
        }
    }

    public class CardioWorkout : Workout
    {

        public int Distance { get; set; }
        public CardioWorkout(DateTime date, string type, TimeSpan duration,
            int caloriesBurned, string notes, int distance)
            : base(date, type, duration, caloriesBurned, notes)
        {
            this.Distance = distance;
        }
        public override int CalculateCalobriesBurned()
        {
            return 0;
        }
    }

    public class StrengthWorkout : Workout
    {

        public int Repetitations { get; set; }
        public StrengthWorkout(DateTime date, string type, TimeSpan duration,
            int caloriesBurned, string notes, int Repetitations)
            : base(date, type, duration, caloriesBurned, notes)
        {
            this.Repetitations = Repetitations;
        }

        public override int CalculateCalobriesBurned()
        {
            return Repetitations / CaloriesBurned;
        }
    }
}
