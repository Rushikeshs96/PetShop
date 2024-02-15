using System;
using System.Collections.Generic;

namespace PetShopBackend.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
