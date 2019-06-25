using Restaurant.Database;
using Restaurant.Domain.DTO;
using System;
using System.Collections.Generic;
namespace Restaurant.Domain.Services.Abstract
{
    public interface IMenuService
    {
        IList<MenuDTO> Get();
    }
}
