// RegisterViewModel.cs
using System.Windows.Input;

namespace Fit_Tracker.MVVM.Models
{
    public class RegisterViewModel : ViewModelBase
    {
        private string username;
        private string password;
        private string country;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }


        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            // Logic to register the user
        }
    }
}
