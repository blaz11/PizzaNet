using System.Windows.Controls;

namespace Pizza.Net.Screens.Pages
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void UserControlDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (e.NewValue as LoginPageViewModel);
            if (viewModel == null)
                return;
            viewModel.HarvestPassword += (sender1, args) => args.Password = PasswordBox.Password;
        }
    }
}
