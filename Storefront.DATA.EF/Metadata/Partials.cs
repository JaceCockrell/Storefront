using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storefront.DATA.EF.Models//.Metadata
{
    //internal class Partials
    //{
    //}

    #region Candle
    [ModelMetadataType(typeof(CandleMetadata))]
    public partial class Candle { }

    #endregion

    #region Category
    [ModelMetadataType(typeof(CategoryMetadata))]
    public partial class Category { }

    #endregion

    #region Order

    [ModelMetadataType(typeof(OrderMetadata))]
    public partial class Order { }

    #endregion

    #region Supplier
    [ModelMetadataType(typeof(SupplierMetadata))]
    public partial class Supplier { }

    #endregion

    #region UserDetail

    [ModelMetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail { }

    #endregion
}

