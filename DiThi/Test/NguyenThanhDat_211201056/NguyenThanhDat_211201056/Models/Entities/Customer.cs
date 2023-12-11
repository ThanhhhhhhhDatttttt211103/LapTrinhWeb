﻿using System;
using System.Collections.Generic;

namespace NguyenThanhDat_211201056.Models.Entities
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
        public string RePassword { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
