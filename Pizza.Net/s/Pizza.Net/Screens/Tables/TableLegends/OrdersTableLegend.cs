using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Net.Screens.Tables.TableLegends
{
    class OrdersTableLegend
    {
        public string Client
        {
            get
            {
                return "Client";
            }
        }

        public string Employee
        {
            get
            {
                return "Employee";
            }
        }

        public string StartDate
        {
            get
            {
                return "Start Date";
            }
        }

        public string FinishDate
        {
            get
            {
                return "Finish Date";
            }
        }

        public ICollection<string> Pizzas
        {
            get
            {
                var list = new List<string>();
                list.Add("Pizzas Ordered");
                return list;
            }
        }
    }
}
