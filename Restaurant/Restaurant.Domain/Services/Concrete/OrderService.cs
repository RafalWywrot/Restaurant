using AutoMapper;
using Restaurant.Database;
using Restaurant.Database.Entities;
using Restaurant.Database.Repositories.Abstract;
using Restaurant.Domain.DTO;
using Restaurant.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Restaurant.Domain.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository { get; }

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IList<OrderDTO> Get()
        {
            var orders = orderRepository.GetAll();
            return Mapper.Map<List<OrderDTO>>(orders);
        }

        public void Add(OrderItemDTO order, ApplicationUser user)
        {
            var parentOrder = orderRepository.GetAll().Where(x => x.User.Name == user.Name && x.User.Surname == user.Surname && x.Status == false).FirstOrDefault();
            if (parentOrder == null)
            {
                var newOrder = new OrderDTO()
                {
                    OrderDate = DateTime.Now,
                    Status = false,
                    User = user,
                    PickupDate = DateTime.Now,
                    OrderItems = new List<OrderItemDTO>() { order }
                };
                orderRepository.InitializeOrder(Mapper.Map<Order>(newOrder));
                return;
            }
            order.OrderParent = new OrderDTO() { Id = parentOrder.Id };
            orderRepository.AddOrderItem(Mapper.Map<OrderItem>(order));
            return;
        }

        public void Remove(int orderItemId)
        {
            orderRepository.Remove(orderItemId);
        }
    }
}
