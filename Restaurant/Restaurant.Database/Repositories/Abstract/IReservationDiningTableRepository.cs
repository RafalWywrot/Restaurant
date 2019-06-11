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
        void AddReservation(int id, DateTime startDate, DateTime endDate, ApplicationUser user);
    }
}
