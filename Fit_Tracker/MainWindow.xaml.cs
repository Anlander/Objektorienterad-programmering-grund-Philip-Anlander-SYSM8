using Fit_Tracker.ViewModels.Register;
using Fit_Tracker.ViewModels.WorkoutsWindow;
using System.Windows;

namespace Fit_Tracker
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow workOut = new WorkoutsWindow();
            workOut.Show();
            Close();

        }
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Register register = new ViewModels.Register.Register();
            register.Show();
            Close();
        }
    }
}