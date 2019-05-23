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
    public class TestRepository : ITestRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public TestRepository(IRestaurantSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }

        public List<Test> GetAll()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<Test>().ToList();
            }
        }
    }
}
