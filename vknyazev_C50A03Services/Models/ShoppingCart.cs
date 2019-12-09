using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class Cart
    {
        [Required]
        [Display(Name = "Cart Id")]
        [DataMember(Name = "CartID")]
        public int CartId { get; set; }
    
    }
}
