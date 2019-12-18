using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vknyazev_C50A03Services.Models
{

    [DataContract]
    public class ShoppingCart
    {
        [Key]
        [DataMember(Name = "cartId")]
        public int CartId { get; set; }
        
        [DataMember(Name = "cartCustId")]
        [ForeignKey("Customer")]
        public int CartCustId { get; set; }
        
        public Customer Customer { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "cartItems")]
        public ICollection<CartItem> CartItems { get; set; }
    }
}