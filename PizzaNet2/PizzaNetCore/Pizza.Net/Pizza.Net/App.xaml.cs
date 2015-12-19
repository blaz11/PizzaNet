using Pizza.Net.Screens;
using Pizza.Net.Screens.Windows;
using System.Windows;

namespace Pizza.Net
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var app = new MainApplicationWindow();
            //var context = new MainApplicationWindowViewModel();
            //app.DataContext = context;
            //app.Title = "Pizza.Net";
            //app.Show();

            var app = new LoginWindow();
            var context = new LoginWindowViewModel();
            app.DataContext = context;
            app.Title = "Pizza.Net";
            app.Show();
        }
    }
}