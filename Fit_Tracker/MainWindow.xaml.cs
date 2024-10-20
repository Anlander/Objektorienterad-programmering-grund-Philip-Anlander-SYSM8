using Fit_Tracker.Classes;
using Fit_Tracker.Pages.Register;
using Fit_Tracker.Pages.WorkoutsWindow;
using Fit_Tracker.ViewModel;
using System.Windows;

namespace Fit_Tracker
{
    public partial class MainWindow : Window
    {
        private static List<User> _userList = new List<User>();

        public MainWindow()
        {

            InitializeComponent();
            //DataContext = new MainWindowViewModel();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            DataContext = viewModel;

        }


        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {

            var viewModel = (MainWindowViewModel)DataContext;
            string username = UserName.Text;
            string password = PassWord.Text;
            User userExist = viewModel.Users.FirstOrDefault(userU => userU.Username == username && userU.Password == password);

            if (userExist != null)
            {
                MessageBox.Show("User Exists!");
                WorkoutsWindow workOut = new WorkoutsWindow(userExist);
                workOut.Show();
                Close();

            }
            else
            {
                MessageBox.Show("Dosen't Exists!");
            }

        }
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            Register register = new Pages.Register.Register();
            register.Show();
            Close();
        }

    }
}