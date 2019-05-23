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
    public class DiningTableRepository : IDiningTableRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public DiningTableRepository(IRestaurantSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }

        public List<DiningTable> GetAll()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<DiningTable>().ToList();
            }
        }
    }
}
