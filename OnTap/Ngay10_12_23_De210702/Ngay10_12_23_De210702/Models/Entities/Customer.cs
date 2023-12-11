using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ngay10_12_23_De210702.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

		[Compare(nameof(Password), ErrorMessage = "Mật khẩu không khớp")]
		public string RePassword { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
