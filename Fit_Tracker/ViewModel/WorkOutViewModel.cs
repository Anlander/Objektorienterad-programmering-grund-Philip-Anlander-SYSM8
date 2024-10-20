using Fit_Tracker.Modules;
using Fit_Tracker.MVVM;
using System.Collections.ObjectModel;

namespace Fit_Tracker.ViewModel
{
    public class WorkOutViewModel : ViewModelBase
    {
        public ObservableCollection<CardioWorkout> CardioWorkOut { get; set; }
        public WorkOutViewModel()
        {

            CardioWorkOut = new ObservableCollection<CardioWorkout>();
            CardioWorkOut.Add(new CardioWorkout(new DateTime(2011, 12, 30), "String", new TimeSpan(1, 12, 23), 200, "No Notes", 145));
            CardioWorkOut.Add(new CardioWorkout(date: new DateTime(2011, 12, 30), type: "String", duration: new TimeSpan(1, 12, 23), calobriesBurned: 200, notes: "No Notes", Distance: 145));
        }
    }
}
