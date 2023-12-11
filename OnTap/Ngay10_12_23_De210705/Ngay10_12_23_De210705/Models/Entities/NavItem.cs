using System;
using System.Collections.Generic;

namespace Ngay10_12_23_De210705.Models.Entities
{
    public partial class NavItem
    {
        public int Id { get; set; }
        public string NavName { get; set; } = null!;
        public string? NavNameVn { get; set; }
    }
}
