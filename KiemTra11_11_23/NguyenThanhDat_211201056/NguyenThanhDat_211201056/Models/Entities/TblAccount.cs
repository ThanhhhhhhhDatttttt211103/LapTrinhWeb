using System;
using System.Collections.Generic;

namespace NguyenThanhDat_211201056.Models.Entities
{
    public partial class TblAccount
    {
        public int Uid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
