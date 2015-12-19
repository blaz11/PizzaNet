using MahApps.Metro.Controls;

namespace Pizza.Net.Screens.Windows
{
    public partial class LoginWindow : MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void MetroWindowDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as CloseableViewModel;
            viewModel.ClosingRequest += (sender1, args) => this.Close();
        }
    }
}