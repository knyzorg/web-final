using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class CartItem
    {
        [Required]
        [Display(Name = "CartItem Id")]
        [DataMember(Name = "cartItemID")]
        public int CartItemId { get; set; }

        [Display(Name = "Product Id")]
        [DataMember(Name = "productID")]
        public int ProductId { get; set; }

        [Display(Name = "Quantity")]
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        [DataMember(Name = "price")]
        public int Price { get; set; }
        
        public Product Product { get; set; }

    }
}
