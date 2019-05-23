using AutoMapper;
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

        public BookTableService(IDiningTableRepository diningTableRepository)
        {
            this.diningTableRepository = diningTableRepository;
        }


        public List<DiningTableDTO> GetAll()
        {
            var allTables = diningTableRepository.GetAll();
            return Mapper.Map<List<DiningTableDTO>>(allTables);
        }
    }
}
