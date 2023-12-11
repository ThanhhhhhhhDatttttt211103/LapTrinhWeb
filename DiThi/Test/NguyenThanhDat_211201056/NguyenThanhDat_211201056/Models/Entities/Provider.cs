using System;
using System.Collections.Generic;

namespace NguyenThanhDat_211201056.Models.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string ProviderName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
