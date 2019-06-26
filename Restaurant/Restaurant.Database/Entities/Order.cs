using System;
using System.Collections.Generic;

namespace Restaurant.Database.Entities
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual bool Status { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
        public virtual DateTime PickupDate { get; set; }
    }
}
