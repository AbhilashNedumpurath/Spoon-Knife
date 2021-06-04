using SampleApp.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp
{
    public class Customer
    {
        private List<IOrderItem> orders;

        public Customer()
        {
            orders = new List<IOrderItem>();
        }
        public void Order(IOrderItem order)
        {
            orders.Add(order);
        }
        public void RemoveOrder(IOrderItem order)
        {
            orders.Remove(order);
        }

        public void DoPayment()
        {
            Console.WriteLine("Payment Done");

            //Executing Rules
            foreach(var order in orders)
            {
                order.ExecuteRules();
            }
        }
    }
}
