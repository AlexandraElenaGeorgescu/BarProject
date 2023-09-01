using System.Collections.Generic;
using BarProject.Database_access;
using BarProject.Models;

namespace BarProject.Services
{
    public class OrderService
    {
        private readonly DatabaseAccess _databaseAccess;

        public OrderService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _databaseAccess.GetOrders();
        }
        public void InsertOrder(Order order)
        {
            _databaseAccess.InsertOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _databaseAccess.UpdateOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            _databaseAccess.DeleteOrder(orderId);
        }
    }
}