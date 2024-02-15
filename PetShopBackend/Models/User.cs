using System;
using System.Collections.Generic;

namespace PetShopBackend.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public int? CustomerCustomerId { get; set; }

        public virtual Customer? CustomerCustomer { get; set; }
    }
}
