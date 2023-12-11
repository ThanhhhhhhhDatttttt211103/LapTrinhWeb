using System;
using System.Collections.Generic;

namespace Ngay10_12_23_De210704.Models.Entities
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
