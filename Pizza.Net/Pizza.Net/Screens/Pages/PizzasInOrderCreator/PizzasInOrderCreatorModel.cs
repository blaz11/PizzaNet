using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    public interface IPizzasInOrderCreatorModel
    {
        ObservableCollection<PizzaViewModel> getPizza();
        ObservableCollection<Size> getSizes();
    }
    public class PizzasInOrderCreatorModel : IPizzasInOrderCreatorModel
    {
        public ObservableCollection<PizzaViewModel> getPizza()
        {
            ObservableCollection<PizzaViewModel> piz = new ObservableCollection<PizzaViewModel>();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            { 

                var a = pne.Pizzas.Where(p => true);
                piz.Clear();
                foreach (var v in a)
                    piz.Add(new PizzaViewModel(v));
                return piz;
            }
                
        }
        public ObservableCollection<Size> getSizes()
        {
            ObservableCollection<Size> siz = new ObservableCollection<Size>();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var b = pne.Sizes.Where(p => true);
                siz.Clear();
                foreach (var v in b)
                    siz.Add(v);

            }
            return siz;
        }
    }
}
