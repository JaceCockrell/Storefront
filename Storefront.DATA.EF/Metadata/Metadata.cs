using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Storefront.DATA.EF.Models//.Metadata
{
    //internal class Metadata
    //{
    //}
    #region Candle Metadata
    public class CandleMetadata
    {
        //public int CandleId { get; set; } Primary Key 
        [Required(ErrorMessage = "*Candle is required")]
        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        [Display(Name = "Candle")]
        public string CandleName { get; set; } = null!;

        [StringLength(500, ErrorMessage ="*Max 500 characters")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "*Price is required")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        //public int? SupplierId { get; set; } foriegn key

        //public int? CategoryId { get; set; } foriegn key

        [StringLength(75)] // wont need error message
        [Display(Name = "Image")]
        public string? CandleImage { get; set; }
    }
    #endregion

    #region Category

    public class CategoryMetadata
    {
        // public int CategoryId { get; set; } primary key

        [StringLength(150, ErrorMessage ="*Max 150 characters")]
        public string CategoryName { get; set; } = null!;
    }

    #endregion

    #region Order

    public class OrderMetadata
    {
        //public int OrderId { get; set; } PK
        [Required(ErrorMessage ="*Order Date is required")]
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]// 0:d => MM/dd/yyyy
        public DateTime? OrderDate { get; set; }
        //public string UserId { get; set; } = null!; FK
    }

    #endregion

    #region Supplier

    public class SupplierMetadata
    {
        // public int SupplierId { get; set; } PK

        [Required(ErrorMessage = "*Supplier is required")]
        [StringLength(200, ErrorMessage = "*Max 200 characters")]
        [Display(Name = "Supplier")]
        public string SupplierName { get; set; } = null!;

        [Required(ErrorMessage = "*Address is required")]
        [StringLength(150, ErrorMessage = "Max 150 characters")]
        public string Address { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "*Max 100 characters")]
        public string? Email { get; set; }

        [StringLength(24, ErrorMessage = "*Max 24 character number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }

    #endregion

    #region UserDetail

    public class UserDetailMetadata
    {
        // public string UserId { get; set; } = null!;
        [Required(ErrorMessage = "*First Name is required")]
        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "*Last Name is required")]
        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "*Max 100 characters")]
        public string? Email { get; set; }

        [StringLength(150, ErrorMessage = "Max 150 characters")]
        public string? Address { get; set; }

        [StringLength(24, ErrorMessage = "*Max 24 character number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public string? PhoneNumber { get; set; }

    }

    #endregion
}
