using MahApps.Metro.Controls;
using Pizza.Net.Screens.Windows;

namespace Pizza.Net.Screens
{
    public partial class MainApplicationWindow : MetroWindow
    {
        public MainApplicationWindow()
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