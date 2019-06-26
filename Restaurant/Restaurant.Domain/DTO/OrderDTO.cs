using Restaurant.Database;
using System;
using System.Collections.Generic;

namespace Restaurant.Domain.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ApplicationUser User { get; set; }
        public bool Status { get; set; }
        public IList<OrderItemDTO> OrderItems { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
