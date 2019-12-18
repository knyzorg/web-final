using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vknyazev_C50A03Services.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int OrderCustId { get; set; }
        public Customer Customer { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateFulfilled { get; set; }

        public decimal Total { get; set; }
        public decimal Taxes { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
