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
    public class ReservationDiningTableRepository : IReservationDiningTableRepository
    {
        private NHibernate.ISessionFactory _sessionFactory { get; }

        public ReservationDiningTableRepository(IRestaurantSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.CreateSessionFactory();
        }

        public IList<ReservationDiningTable> GetAll()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<ReservationDiningTable>().ToList();
            }
        }

        public void AddReservation(int id, DateTime startDate, DateTime endDate)
        {
            // how to pass userid into reservarion dining tableS
            var reservation = new ReservationDiningTable
            {
                DiningTable = new DiningTable { Id = id },
                StartDate = startDate,
                EndDate = endDate,
                User = new ApplicationUser { Id= "0de7a44b-8483-4dd4-ac51-b5d989dfb20d" }
            };

            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(reservation);
            }
        }
    }
}
