using System;
using System.Collections.Generic;

namespace NguyenThanhDat_211201056.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameVn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
