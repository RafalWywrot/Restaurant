using Restaurant.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services.Abstract
{
    public interface IBookTableService
    {
        IList<DiningTableDTO> GetTables();
        IList<int> GetChairsOptions();
        IList<ReservationDiningTableDTO> GetReservations();
        IList<DiningTableDTO> GetAvailableTables(int chairs, DateTime startDate, DateTime endDate);
        void ReserveTable(int id, DateTime startDate, DateTime endDate);
    }
}
