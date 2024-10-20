using Fit_Tracker.Classes;
using Fit_Tracker.MVVM;
using System.Windows;

namespace Fit_Tracker.Pages.WorkoutsWindow
{

    public partial class WorkoutsWindow : Window
    {

        public WorkoutsWindow(User currentUser)
        {

            InitializeComponent();
            DataContext = new WorkOutsWindowModel(currentUser);

        }
    }
}
