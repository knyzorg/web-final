using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public class Customer
    {
        public Customer() {
            Orders = new HashSet<Order>();
        }
        [DataMember(Name="customerId")]
        public int CustomerId { get; set; }
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }
        [DataMember(Name="lastName")]
        public string LastName { get; set; }
        [DataMember(Name="email")]
        public string Email { get; set; }
        [DataMember(Name="phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name="province")]
        public string Province { get; set; }
        [DataMember(Name="creditCad")]
        public string CreditCad { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
