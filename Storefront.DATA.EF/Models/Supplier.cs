using System;
using System.Collections.Generic;

namespace Storefront.DATA.EF.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Candles = new HashSet<Candle>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Candle> Candles { get; set; }
    }
}
