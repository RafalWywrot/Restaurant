using Restaurant.Database.Entities;
using System.Collections.Generic;

namespace Restaurant.Database.Repositories.Abstract
{
    public interface IOrderRepository
    {
        IList<Order> GetAll();
        void InitializeOrder(Order order);
        void AddOrderItem(OrderItem orderItem);
        void Remove(int orderItemId);
    }
}
