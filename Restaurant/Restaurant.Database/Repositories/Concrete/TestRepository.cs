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
        public List<Test> GetAll()
        {
            using (ISession session = nhibernateHelper.OpenSession())
            {
                return session.Query<Test>().ToList();
            }
        }
    }
}
