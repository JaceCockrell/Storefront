﻿using System;
using System.Collections.Generic;

namespace Storefront.DATA.EF.Models
{
    public partial class Candle
    {
        public Candle()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int CandleId { get; set; }
        public string CandleName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string? CandleImage { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
