using System;
using System.Collections.Generic;

namespace PetShopBackend.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateOnly DispatchDate { get; set; }
        public DateOnly OrderDate { get; set; }
        public float TotalCost { get; set; }
        public int? CustomerCustomerId { get; set; }
        public int? ProductsProductId { get; set; }

        public virtual Customer? CustomerCustomer { get; set; }
        public virtual Product? ProductsProduct { get; set; }
    }
}
