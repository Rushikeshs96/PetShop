using System;
using System.Collections.Generic;

namespace PetShopBackend.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string? ProductBreed { get; set; }
        public string Category { get; set; } = null!;
        public float ProductCost { get; set; }
        public string? Description { get; set; }
        public string ProductName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
