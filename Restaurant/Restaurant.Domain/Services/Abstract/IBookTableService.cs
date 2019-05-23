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
        List<DiningTableDTO> GetAll();
    }
}
