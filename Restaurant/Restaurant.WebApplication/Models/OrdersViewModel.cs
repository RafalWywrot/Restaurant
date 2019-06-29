using Restaurant.Domain.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.WebApplication.Models
{
    public class OrdersViewModel
    {        
        public OrderDTO ActiveOrder { get; set; }
        public IList<OrderDTO> HistoryOrders { get; set; }
    }
}