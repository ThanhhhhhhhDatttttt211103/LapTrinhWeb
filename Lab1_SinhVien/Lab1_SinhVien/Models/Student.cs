using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace Lab1_SinhVien.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name phải bắt buộc")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+\.[A-Za-z]{2,4}")]
        public string? Email { get; set; }
        [StringLength(100, MinimumLength = 8)]
        [Required]
        public string? Password { get; set; }
        [Required]
        public Branch? Branch { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public bool IsRegular { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime DateOfBorth { get; set; }
    } 
}
