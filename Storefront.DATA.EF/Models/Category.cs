using System;
using System.Collections.Generic;

namespace Storefront.DATA.EF.Models
{
    public partial class Category
    {
        public Category()
        {
            Candles = new HashSet<Candle>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Candle> Candles { get; set; }
    }
}
