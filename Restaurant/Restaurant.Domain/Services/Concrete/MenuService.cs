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
    public class MenuService : IMenuService
    {
        private IMenuRepository menuRepository { get; }

        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        public IList<MenuDTO> Get()
        {
            var menu = menuRepository.GetAll();
            return Mapper.Map<List<MenuDTO>>(menu);
        }
    }
}
