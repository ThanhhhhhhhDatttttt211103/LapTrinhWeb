using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ngay10_12_23_De210704.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

		[RegularExpression(@"^(?:[1-9]\d{2,}|\d{4,})(\.\d+)?$", ErrorMessage = "UnitPrice phải là số")]
		public double UnitPrice { get; set; }
        public string? Image { get; set; }
		public bool Available { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }

        public virtual Category? Category { get; set; } = null!;
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
