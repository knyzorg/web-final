using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class Order
    {
        [Required]
        [Display(Name = "Order Id")]
        [DataMember(Name = "OrderID")]
        public int OrderId { get; set; }
    
    }
}
