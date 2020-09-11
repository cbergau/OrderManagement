using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Entities;
using OrderManagement.Repository.Entity;

namespace OrderManagement.Repository
{
    public class EntityFrameworkOrderRepository : IOrderRepository
    {
        public Order Find(string orderId)
        {
            using var db = new OrderContext();
            var entity = db.Find<OrderEntity>(orderId);

            return new Order {Id = entity.id, State = entity.state};
        }

        public void Save(Order order)
        {
            using var db = new OrderContext();

            if (order.Id == null)
            {
                var orderEntity = CreateNewOrder(order, db);
                order.Id = orderEntity.id;
            }
            else
            {
                var fromDb = db.Find<OrderEntity>(order.Id);
                fromDb.state = order.State;
            }

            db.SaveChanges();
        }

        public IEnumerable<Order> FindAll()
        {
            using var db = new OrderContext();

            return db.Orders
                .Select(orderEntity => new Order {Id = orderEntity.id, State = orderEntity.state})
                .ToList();
        }

        private static OrderEntity CreateNewOrder(Order order, DbContext db)
        {
            var orderEntity = new OrderEntity {id = order.Id ?? Guid.NewGuid().ToString(), state = order.State};
            db.Add(orderEntity);
            return orderEntity;
        }
    }
}