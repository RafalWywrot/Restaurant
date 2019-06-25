using Restaurant.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Repositories.Abstract
{
    public interface IMenuRepository
    {
        IList<Menu> GetAll();
    }
}
