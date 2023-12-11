using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Lab1_SinhVien.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Tên")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name tối thiểu 4 ký tự, tối đa 100 ký tự")]
        [Required(ErrorMessage = "Name bắt buộc phải được nhập")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Địa chỉ email phải có đuôi gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(100, MinimumLength = 8)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}", ErrorMessage = "Mật khẩu từ 8 ký tự trở lên, có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        [Required]
        public string? Password { get; set; }

        [Display(Name = "Ngành")]
        [Required(ErrorMessage = "Ngành bắt buộc phải được chọn")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Giới tính bắt buộc phải được chọn")]
        public Gender? Gender { get; set; }

        [Display(Name = "Chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        public string? Address { get; set; }


        [Display(Name = "Ngày sinh")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải nằm trong khoảng từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập")]
        public DateTime DateOfBorth { get; set; }

        [Display(Name = "Điểm")]
        [RegularExpression(@"^(?:10(?:\.0)?|[0-9](?:\.\d)?)$", ErrorMessage = "Điểm từ 0.0 đến 10.0")]
        [Required(ErrorMessage = "Điểm bắt buộc phải được nhập")]
        public double? Marks { get; set; }

    }
}
