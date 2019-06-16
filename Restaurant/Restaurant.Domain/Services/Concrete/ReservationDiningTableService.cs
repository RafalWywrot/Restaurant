using AutoMapper;
using Microsoft.AspNet.Identity;
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
    public class ReservationDiningTableService : IReservationDiningTableService
    {
        private IReservationDiningTableRepository reservationDiningTableRepository { get; }
        public ReservationDiningTableService(IReservationDiningTableRepository reservationDiningTableRepository)
        {
            this.reservationDiningTableRepository = reservationDiningTableRepository;
        }
        public List<ReservationDiningTableDTO> GetReservations(string userId)
        {            
            var userResevations = reservationDiningTableRepository.GetUserReservations(userId);
            return Mapper.Map<List<ReservationDiningTableDTO>>(userResevations);
        }

        public void CancelReservation(int reservationId)
        {
            reservationDiningTableRepository.DeleteReservation(reservationId);
        }
    }
}
