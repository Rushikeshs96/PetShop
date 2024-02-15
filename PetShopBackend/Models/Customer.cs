using System;
using System.Collections.Generic;

namespace PetShopBackend.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPassword { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
