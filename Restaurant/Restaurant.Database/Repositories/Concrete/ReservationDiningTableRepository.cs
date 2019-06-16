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

        public List<ReservationDiningTable> GetUserReservations(string userId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<ReservationDiningTable>().Where(x => x.User.Id == userId).ToList();
            }
        }

        public void AddReservation(int tableId, DateTime startDate, DateTime endDate, ApplicationUser user)
        {                        
            var reservation = new ReservationDiningTable
            {
                DiningTable = new DiningTable { Id = tableId },
                StartDate = startDate,
                EndDate = endDate,
                User = user
            };

            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(reservation);
            }
        }

        public void DeleteReservation(int reservationId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                var reservation = session.Query<ReservationDiningTable>().Where(x => x.Id == reservationId).FirstOrDefault();


                if (reservation != null)
                {
                    session.Delete(reservation);
                    session.Flush();
                }
                else
                {
                    throw new KeyNotFoundException("Key not found in database");
                }

            }
        }
    }
}
