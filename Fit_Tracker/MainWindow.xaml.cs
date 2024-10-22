using Fit_Tracker.Classes;
using Fit_Tracker.MVVM.Views;
using Fit_Tracker.Pages.WorkoutsWindow;
using Fit_Tracker.ViewModel;
using System.Windows;


namespace Fit_Tracker
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;

        }


        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserName.Text;
            string password = PassWord.Text;
            var viewModel = (MainWindowViewModel)DataContext;

            User userExist = viewModel.Users.FirstOrDefault(userU => userU.Username == username && userU.Password == password);

            if (userExist != null)
            {
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
            var viewModel = (MainWindowViewModel)DataContext;
            Register register = new Register(viewModel);
            register.Show();
        }


    }
}