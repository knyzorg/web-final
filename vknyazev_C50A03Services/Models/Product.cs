using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class Product
    {
        [Required]
        [Display(Name = "Product Id")]
        [DataMember(Name = "productID")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Category")]
        [DataMember(Name = "prodCatID")]
        public int? ProdCatId { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        [DataMember(Name = "manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Stock")]
        [DataMember(Name = "stock")]
        public int? Stock { get; set; }

        [Required]
        [Display(Name = "Buy Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataMember(Name = "buyPrice")]
        public decimal? BuyPrice { get; set; }

        [Required]
        [Display(Name = "Sell Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataMember(Name = "sellPrice")]
        public decimal? SellPrice { get; set; }

        [Display(Name = "Category")]
        [DataMember(Name = "prodCat")]
        public virtual ProductCategory ProdCat { get; set; }
    }
}
