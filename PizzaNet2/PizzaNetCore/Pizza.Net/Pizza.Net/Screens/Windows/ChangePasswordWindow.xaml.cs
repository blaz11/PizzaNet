using MahApps.Metro.Controls;

namespace Pizza.Net.Screens.Windows
{
    public partial class ChangePasswordWindow : MetroWindow
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void UserControlDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (e.NewValue as ChangePasswordWindowViewModel);
            if (viewModel == null)
                return;
            viewModel.HarvestOldPassword += (sender1, args) => args.Password = OldPasswordBox.Password;
            viewModel.HarvestNewPassword += (sender1, args) => args.Password = NewPasswordBox.Password;
            viewModel.HarvestNewPasswordConfirm += (sender1, args) => args.Password = NewPasswordConfirmBox.Password;
            viewModel.ClosingRequest += (sender1,args) => this.Close();
        }
    }
}