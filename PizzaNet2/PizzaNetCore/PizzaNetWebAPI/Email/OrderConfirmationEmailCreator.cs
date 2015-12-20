using PizzaNetCore;
using System;

namespace PizzaNetWebAPI.Email
{
    public class OrderConfirmationEmailCreator : EmailCreator
    {
        private OrderModel _orderModel;
        private ClientModel _clientModel;

        public OrderConfirmationEmailCreator(OrderModel orderModel, ClientModel clientModel)
        {
            _clientModel = clientModel;
            _orderModel = orderModel;
        }

        public override string GetBody()
        {
            string s = $@"
Pizza Net Confirmation
Your order has been received and is currently being processed
Client
Name: {_clientModel.FirstName} {_clientModel.LastName}
Address: {_clientModel.Street} {_clientModel.PremiseNumber}/{_clientModel.FlatNumber}, {_clientModel.City} {_clientModel.ZipCode}
Order
";
            foreach(var item in _orderModel.Pizzas)
            {
                s += $@"{item.PizzaModel.Name}, {item.SizeModel.Name}, {item.PizzaModel.Price * item.SizeModel.PriceMultiplier}
";
            }
            return s;
        }

        public override string GetSubject()
        {
            return "PizzaNet Order Confirmation - " + _orderModel.StartOrderDate.ToLongDateString() + _orderModel.StartOrderDate.ToShortTimeString();
        }
    }
}