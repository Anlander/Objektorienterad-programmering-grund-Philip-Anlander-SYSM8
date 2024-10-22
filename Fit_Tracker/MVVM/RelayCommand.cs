using System.Windows.Input;

namespace Fit_Tracker.MVVM
{
    public class RelayCommand : ICommand
    {

        // Fält för referenser till metoder
        private Action<object> execute;
        // Kollar om commandot kan köras
        private Func<object, bool> canExecute;


        // Signalerar när en knapp har körts / ändrats.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public RelayCommand(Action<object> exectute, Func<object, bool>? canExecute = null)
        {
            this.execute = exectute;
            this.canExecute = canExecute;
        }

        // körs eller inte

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);

        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }


}
