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
            ////Przykład użycia
            //var dbAcess = new PizzaNetDbAccess();
            //try {
            //    dbAcess.ExecuteInTransaction(oc =>
            //    {
            //        var p = new Position()
            //        {
            //            Name = "CEO"
            //        };
            //        oc.Entities.Positions.Add(p);
            //    });
            //}
            //catch
            //{
            //    int i = 0;
            //}
            //try {
            //    dbAcess.ExecuteInTransaction(oc =>
            //    {
            //        var query = oc.Entities.Positions.Where(po => po.Name == "CEO");
            //        foreach(var r in query)
            //        {
            //            int i = 0;
            //        }
            //    });
            //}
            //catch
            //{
            //    int i = 0;
            //}
        }
    }
}