using System;
using System.Collections.Generic;

namespace Ngay10_12_23_De210705.Models.Entities
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; } = null!;
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
