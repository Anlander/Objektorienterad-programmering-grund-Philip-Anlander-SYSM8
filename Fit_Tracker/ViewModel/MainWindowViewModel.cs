using Fit_Tracker.Classes;
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
            Users.Add(new User("username", "password", "Sweden"));
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
