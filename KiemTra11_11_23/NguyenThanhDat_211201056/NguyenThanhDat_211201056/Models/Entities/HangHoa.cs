using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenThanhDat_211201056.Models.Entities
{
    public partial class HangHoa
    {
        public int MaHang { get; set; }
        public int MaLoai { get; set; }
        public string TenHang { get; set; } = null!;

        [Column(TypeName = "numeric")]
        [RegularExpression(@"[1-9][0-9]*", ErrorMessage = "Giá phải là số")]
        [Range(100,5000, ErrorMessage = "Giá nằm trong khoảng 100 đến 5000")]
		public decimal? Gia { get; set; }
        public string? Anh { get; set; }

        public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
    }
}
