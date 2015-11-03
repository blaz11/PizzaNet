using Pizza.Net.Screens;
using System.Windows;

namespace Pizza.Net
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var app = new MainApplicationWindow();
            var context = new MainApplicationWindowViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}