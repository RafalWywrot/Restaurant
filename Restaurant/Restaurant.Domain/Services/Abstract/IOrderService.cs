using Restaurant.Database;
using Restaurant.Domain.DTO;
using System.Collections.Generic;
namespace Restaurant.Domain.Services.Abstract
{
    public interface IOrderService
    {
        IList<OrderDTO> Get();
        void Add(OrderItemDTO order, ApplicationUser user);
        void Remove(int orderItemId);
        void Confirm(int orderId);
    }
}
