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
    public class MenuRepository : IMenuRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public MenuRepository(IRestaurantSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }

        public IList<Menu> GetAll()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<Menu>().ToList();
            }
        }
    }
}
