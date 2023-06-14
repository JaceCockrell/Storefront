using System;
using System.Collections.Generic;

namespace Storefront.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; } = null!;

        public virtual UserDetail User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
