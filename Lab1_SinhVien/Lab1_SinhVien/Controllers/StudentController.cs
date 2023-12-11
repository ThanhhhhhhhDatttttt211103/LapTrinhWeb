using Lab1_SinhVien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1_SinhVien.Controllers
{
    
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Thành Đạt", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2021", Email = "Dat@gmail.com" },
                new Student() { Id = 102, Name = "Văn Hoàn", Branch = Branch.CE, Gender = Gender.Male, IsRegular = true, Address = "A2-2021", Email = "Hoan@gmail.com" },
                new Student() { Id = 103, Name = "Việt Hoàng", Branch = Branch.EE, Gender = Gender.Female, IsRegular = true, Address = "A3-2021", Email = "Hoang@gmail.com"},
                new Student() { Id = 104, Name = "Đức Thắng", Branch = Branch.BE, Gender = Gender.Male, IsRegular = false, Address = "A4-2021", Email = "Thang@gmail.com" }
            };
        }


        [Route("Admin/Student/List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }


        [Route("Admin/Student/Add")]
        [HttpGet]
        public IActionResult Create() {
            //lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //lấy danh sách các giá trinh Branch để hiển thị select-opiton trên form
            //Để hiển thị select-opiton trên View cần dùng Lít<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1"},
                new SelectListItem { Text = "BE", Value = "2"},
                new SelectListItem { Text = "CE", Value = "3"},
                new SelectListItem { Text = "EE", Value = "4"},

            };
            return View();
        }
        [Route("Admin/Student/Add")]
        [HttpPost]
        public IActionResult Create(Student s) {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id +1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }           
             return Create();
            
        }
    }
}
