using NHibernate;
using Restaurant.Database.Entities;
using Restaurant.Database.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public OrderRepository(IRestaurantSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }

        public IList<Order> GetAll()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<Order>().ToList();
            }
        }

        public void InitializeOrder(Order order)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.Transaction)
                {
                    transaction.Begin();
                    session.Save(order);
                    transaction.Commit();
                }
            }
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.Transaction)
                {
                    transaction.Begin();
                    var orderDAO = session.Query<Order>().Where(x => x.Id == orderItem.OrderParent.Id).FirstOrDefault();
                    orderDAO.OrderItems.Add(orderItem);
                    session.Update(orderDAO);
                    transaction.Commit();
                }
            }
        }

        public void Remove(int orderItemId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.Transaction)
                {
                    transaction.Begin();
                    var orderItemDAO = session.Query<OrderItem>().Where(x => x.Id == orderItemId).FirstOrDefault();
                    var order = session.Query<Order>().Where(x => x.Id == orderItemDAO.OrderParent.Id).FirstOrDefault();
                    if (order.OrderItems.Count > 1)
                    {
                        order.OrderItems.Remove(orderItemDAO);
                        //session.Delete(orderItemDAO);
                    }
                    else
                    {
                        session.Delete(order);
                    }
                    transaction.Commit();
                }
            }
        }
    }
}
