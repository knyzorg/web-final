using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace vknyazev_C50A03Services.Models
{
    [DataContract]
    public partial class ProductCategory
    {

        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }

        [Display(Name = "Category Id")]
        [DataMember(Name = "categoryId")]
        public int CategoryId { get; set; }


        [Display(Name = "Category")]
        [DataMember(Name = "prodCat")]
        public string ProdCat { get; set; }

        [Display(Name = "Products")]
        public virtual ICollection<Product> Product { get; set; }
    }
}