using AutoMapper;
using Restaurant.Database.Entities;
using Restaurant.Database.Repositories.Abstract;
using Restaurant.Domain.DTO;
using Restaurant.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services.Concrete
{
    public class BookTableService : IBookTableService
    {
        private IDiningTableRepository diningTableRepository { get; }
        private IReservationDiningTableRepository reservationDiningTableRepository { get; }

        public BookTableService(IDiningTableRepository diningTableRepository, IReservationDiningTableRepository reservationDiningTableRepository)
        {
            this.diningTableRepository = diningTableRepository;
            this.reservationDiningTableRepository = reservationDiningTableRepository;
        }


        public IList<DiningTableDTO> GetTables()
        {
            var allTables = diningTableRepository.GetAll();
            return Mapper.Map<List<DiningTableDTO>>(allTables);
        }

        public IList<int> GetChairsOptions()
        {
            var tables = diningTableRepository.GetAll().Select(x => x.AvailableChairs).Distinct().ToList();
            return tables;
        }

        public IList<ReservationDiningTableDTO> GetReservations()
        {
            var allReservations = reservationDiningTableRepository.GetAll();
            return Mapper.Map<List<ReservationDiningTableDTO>>(allReservations);
        }

        public IList<DiningTableDTO> GetAvailableTables(int chairs, DateTime startDate, DateTime endDate)
        {
            var tables = diningTableRepository.GetByChairs(chairs);
            var availableTables = new List<DiningTableDTO>();
            foreach (var table in tables)
            {
                List<ReservationDiningTable> allReservationsForTable = reservationDiningTableRepository.GetAll().Where(x => x.DiningTable.Id == table.Id).ToList();
                if (allReservationsForTable.Count == 0)
                {
                    availableTables.Add(Mapper.Map<DiningTableDTO>(table));
                    continue;
                }

                bool isTableUnavailableForThisDate = allReservationsForTable
                .Any(x =>
                    (x.StartDate >= startDate && x.StartDate <= endDate) ||
                    (x.StartDate <= startDate && x.EndDate >= startDate) );

                if (!isTableUnavailableForThisDate)
                    availableTables.Add(Mapper.Map<DiningTableDTO>(table));
            }
            return availableTables;
        }

        public void ReserveTable(int id, DateTime startDate, DateTime endDate)
        {
            reservationDiningTableRepository.AddReservation(id, startDate, endDate);
        }
    }
}
