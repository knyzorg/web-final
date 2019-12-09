using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class OrderItem
    {
        [Required]
        [Display(Name = "OrderItem Id")]
        [DataMember(Name = "OrderItemID")]
        public int OrderItemId { get; set; }
    
    }
}
