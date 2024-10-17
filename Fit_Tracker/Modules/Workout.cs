namespace Fit_Tracker.Modules
{
    public abstract class Workout
    {
        // Egenskaper
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }
        public int CalobriesBurned { get; set; }
        public string Notes { get; set; }

        // Abstrakt som måste implementeras i subklasserna


        public abstract int CalculateCalobriesBurned();


        // Konstruktor
        public Workout(DateTime date, string type, TimeSpan duration, int calobriesBurned, string notes)
        {
            Date = date;
            Type = type;
            Duration = duration;
            CalobriesBurned = calobriesBurned;
            Notes = notes;
        }
    }

    public class CardioWorkout : Workout
    {

        public int Distance { get; set; }
        public CardioWorkout(DateTime date, string type, TimeSpan duration,
            int calobriesBurned, string notes, int Distance)
            : base(date, type, duration, calobriesBurned, notes)
        {
            this.Distance = Distance;
        }
        public override int CalculateCalobriesBurned()
        {
            return 0;
        }
    }

    public class StrenghtWorkout : Workout
    {

        public int Repetitations { get; set; }
        public StrenghtWorkout(DateTime date, string type, TimeSpan duration,
            int calobriesBurned, string notes, int Repetitations)
            : base(date, type, duration, calobriesBurned, notes)
        {
            this.Repetitations = Repetitations;
        }

        public override int CalculateCalobriesBurned()
        {
            return Repetitations / CalobriesBurned;
        }
    }
}
