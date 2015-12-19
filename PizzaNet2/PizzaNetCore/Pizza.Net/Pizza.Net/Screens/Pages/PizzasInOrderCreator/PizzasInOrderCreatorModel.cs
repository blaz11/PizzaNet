using PizzaNetCore;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Pages
{
    public interface IPizzasInOrderCreatorModel
    {
        ObservableCollection<PizzaModel> GetPizza();
        ObservableCollection<SizeModel> GetSizes();
    }

    public class PizzasInOrderCreatorModel : IPizzasInOrderCreatorModel
    {
        public ObservableCollection<PizzaModel> GetPizza()
        {
            ObservableCollection<PizzaModel> piz = new ObservableCollection<PizzaModel>();
            return piz;
            //using (PizzaNetEntities pne = new PizzaNetEntities())
            //{

            //    var a = pne.Pizzas.Where(p => true);
            //    piz.Clear();
            //    foreach (var v in a)
            //        piz.Add(new PizzaViewModel(v));
            //    return piz;
            //}
        }

        public ObservableCollection<SizeModel> GetSizes()
        {
            ObservableCollection<SizeModel> siz = new ObservableCollection<SizeModel>();
            return siz;
            //using (PizzaNetEntities pne = new PizzaNetEntities())
            //{
            //    var b = pne.Sizes.Where(p => true);
            //    siz.Clear();
            //    foreach (var v in b)
            //        siz.Add(v);

            //}
            //return siz;
        }
    }
}