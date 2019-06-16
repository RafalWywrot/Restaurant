using Restaurant.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Repositories.Abstract
{
    public interface IReservationDiningTableRepository
    {
        IList<ReservationDiningTable> GetAll();
        List<ReservationDiningTable> GetUserReservations(string userId);
        void AddReservation(int id, DateTime startDate, DateTime endDate, ApplicationUser user);
        void DeleteReservation(int reservationId);
    }
}
