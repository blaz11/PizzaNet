using Pizza.Net.Screens.Tables;
using Pizza.Net.Domain;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Pizza.Net.Screens.Pages
{
    interface IPizzasInOrderCreatorViewModel: IPageViewModel
    {
        ICommand AddPizzaCommands { get; }
        ICommand RemovePizzaCommand { get; }
        IPizzasTableViewModel SearchPizzasViewModel { get; }
        IPizzasTableViewModel SelectedPizzasViewModel { get; }
        ISizesTableViewModel SizesTableViewModel { get; }
    }

    class PizzasInOrderCreatorViewModel : IPizzasInOrderCreatorViewModel
    {
        public PizzasInOrderCreatorViewModel()
        {
            SearchPizzasViewModel = new PizzasTableViewModel();
            SelectedPizzasViewModel = new PizzasTableViewModel();
            SizesTableViewModel = new SizesTableViewModel();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {

                var a = pne.Pizzas.Where(p => true);
                SearchPizzasViewModel.Pizzas.Clear();
                foreach (var v in a)
                    SearchPizzasViewModel.Pizzas.Add(new PizzaViewModel(v));

                var b = pne.Sizes.Where(p => true);
                SizesTableViewModel.Sizes.Clear();
                foreach (var v in b)
                    SizesTableViewModel.Sizes.Add(v);

            }
            Console.WriteLine();

        }
        public ObservableCollection<Size> sizes = new ObservableCollection<Size>();
        public string PageName
        {
            get
            {
                return "Select Pizzas";
            }
        }

        public ISizesTableViewModel SizesTableViewModel { get; private set; }
        public IPizzasTableViewModel SearchPizzasViewModel { get; private set; }
        public IPizzasTableViewModel SelectedPizzasViewModel { get; private set; }

        private ICommand _removePizzaCommand;
        public ICommand RemovePizzaCommand
        {
            get
            {
                if (_removePizzaCommand == null)
                {
                    _removePizzaCommand = new RelayCommand(
                        param => RemovePizza());
                }
                return _removePizzaCommand;
            }
        }

        private ICommand _addPizzaCommands;
        public ICommand AddPizzaCommands
        {
            get
            {
                if (_addPizzaCommands == null)
                {
                    _addPizzaCommands = new RelayCommand(
                        param => AddPizza());
                }
                return _addPizzaCommands;
            }
        }

        private void AddPizza()
        {
            var item = SearchPizzasViewModel.SelectedPizza;
            if (item == null)
                return;
            var item2 = SizesTableViewModel.SelectedSize;
            if (item2 == null)
                return;
            SearchPizzasViewModel.Pizzas.Remove(item);
            SelectedPizzasViewModel.Pizzas.Add(item);
            sizes.Add(item2);


        }

        private void RemovePizza()
        {
            var item = SelectedPizzasViewModel.SelectedPizza;
            if (item == null)
                return;
            sizes.RemoveAt(SelectedPizzasViewModel.Pizzas.IndexOf(item));
           // SelectedPizzasViewModel.Pizzas.IndexOf(item);
            SelectedPizzasViewModel.Pizzas.Remove(item);
            SearchPizzasViewModel.Pizzas.Add(item);
        }
    }
}
