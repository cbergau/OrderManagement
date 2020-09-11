using System;
using System.Collections.Generic;
using OrderManagement.Entities;

namespace OrderManagement.Repository
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly Dictionary<string, Order> Orders = new Dictionary<string, Order>();


        public Order Find(string orderId)
        {
            return Orders.GetValueOrDefault(orderId, null);
        }

        public void Save(Order order)
        {
            order.Id ??= Guid.NewGuid().ToString();
            Orders[order.Id] = order;
        }
    }
}
