using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class Customer
    {
        [Required]
        [Display(Name = "Customer Id")]
        [DataMember(Name = "CustomerID")]
        public int CustomerId { get; set; }
    
    }
}
