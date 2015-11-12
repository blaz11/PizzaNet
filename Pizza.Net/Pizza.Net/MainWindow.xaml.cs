using Pizza.Net.Domain;
using Pizza.Net.Domain.DatabaseAccess;
using System.Windows;
using System.Linq;

namespace Pizza.Net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Przykład użycia
            var dbAcess = new PizzaNetDbAccess();
            //dbAcess.ExecuteInTransaction(oc =>
            //{
            //    var p = new Position()
            //    {
            //        Name = "CEO"
            //    };
            //    oc.Entities.Positions.Add(p);
            //    var query = oc.Entities.Positions.Where(po => po.Name == p.Name);
            //    var postition = query.First();
            //});
            dbAcess.ExecuteInTransaction(oc =>
            {
                var query = oc.Entities.Positions.Where(po => po.Name == "CEO");
                var postition = query.First();
            });
        }
    }
}