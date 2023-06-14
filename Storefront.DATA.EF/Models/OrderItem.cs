using System;
using System.Collections.Generic;

namespace Storefront.DATA.EF.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int CandleId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual Candle Candle { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
