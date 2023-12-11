namespace QuanLySanBong.Models
{
    public class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool? LoaiUser { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
