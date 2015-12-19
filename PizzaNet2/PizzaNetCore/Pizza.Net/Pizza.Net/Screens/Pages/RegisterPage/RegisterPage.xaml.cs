using System.Windows.Controls;

namespace Pizza.Net.Screens.Pages
{
    public partial class RegisterPage : UserControl
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void UserControlDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (e.NewValue as RegisterPageViewModel);
            if (viewModel == null)
                return;
            viewModel.HarvestPassword += (sender1, args) => args.Password = PasswordBox.Password;
            viewModel.HarvestConfirmPassword += (sender1, args) => args.Password = PasswordConfirmBox.Password;
        }
    }
}
