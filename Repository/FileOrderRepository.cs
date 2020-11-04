using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using OrderManagement.Entities;

namespace OrderManagement.Repository
{
    public class FileOrderRepository : IOrderRepository
    {
        public Order Find(string orderId)
        {
            var path = BuildPath(orderId);
            return !File.Exists(path) ? null : GetByPath(path);
        }

        public void Save(Order order)
        {
            order.Id ??= Guid.NewGuid().ToString();
            File.WriteAllText(BuildPath(order.Id), JsonSerializer.Serialize(order));
        }

        public IEnumerable<Order> FindAll()
        {
            return Directory
                .GetFiles("./Orders")
                .Select(GetByPath)
                .ToList();
        }

        private static Order GetByPath(string path)
        {
            return JsonSerializer.Deserialize<Order>(File.ReadAllText(path));
        }

        private static string BuildPath(string orderId)
        {
            return $"./Orders/order_{orderId.Replace("-", "_")}.json";
        }
    }
}