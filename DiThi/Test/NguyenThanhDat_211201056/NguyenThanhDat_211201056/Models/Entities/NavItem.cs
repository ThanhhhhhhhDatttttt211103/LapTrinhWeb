using System;
using System.Collections.Generic;

namespace NguyenThanhDat_211201056.Models.Entities
{
    public partial class NavItem
    {
        public int Id { get; set; }
        public string NavName { get; set; } = null!;
        public string? NavNameVn { get; set; }
    }
}
