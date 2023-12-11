using Lab1_SinhVien.Data;
using Lab1_SinhVien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Lab1_SinhVien.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;
        //private int pageSize = 3;
        public LearnerController(SchoolContext context)
        {
            db = context;
        }
        private int pageSize = 3;
        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners
                .Include(m => m.Major);
            if (mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners
                    .Where(l => l.MajorID == mid)
                    .Include(m => m.Major);
            }
            //tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            //trả số trnag về view ddeer hiển thị nav-trang
            ViewBag.pageNum = pageNum;
            //lấy dữ liệu trang đầu
            var result = learners.Take(pageSize).ToList();
            return View(result);
        }

        //thêm 2 action create
        public IActionResult Create()
        {
            //dùng 1 trong 2 cách để tạo SelectList gửi về View qua ViewBag để
            //hiển thị danh sách chuyên ngành (Majors)
            var majors = new List<SelectListItem>(); //cách 1
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                });

            }
            ViewBag.MajorID = majors;
            //ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName"); //cách 2
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")]
Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //lại dùng 1 trong 2 cách tạo SelectList gửi về View để hiển thị danh sách Majors
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            Learner learner = db.Learners.Find(ID);
            if (learner != null)
            {
                ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName"); //cách 2               
                return View(learner);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Update(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //lại dùng 1 trong 2 cách tạo SelectList gửi về View để hiển thị danh sách Majors
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }



        public IActionResult Delete(int? ID)
        {
            Learner learner = db.Learners.Find(ID);
            if(learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = db.Learners
                .Where(l=>l.MajorID == mid) 
                .Include(m  => m.Major).ToList();
            return PartialView("LearnerTable", learners);
        }
        
        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            //lấy toàn bộ learners trong dbset chuyển về IQuerrable<Learner> để query
            var learners = (IQueryable<Learner>)db.Learners;
            //Lấy chỉ sổ trang, nếu chỉ số trang null thì gán ngầm định bằng 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            //nếu có mid thì lọc learner theo mid (chuyên ngành)
            if (mid != null)
            {
                //lọc
                learners = learners.Where(l => l.MajorID == mid);
                //gửi id về view để ghi lại trên nav-phân trang
                ViewBag.mid = mid;
            }
            //nếu có keyword thì  tìm kiếm theo tên
            if (keyword != null)
            {
                //tìm kiếm
                learners = learners.Where(l => l.FirstMidName.ToLower()
                                           .Contains(keyword.ToLower()));
                //gửi keyword về view để ghi trên nav-phân trang
                ViewBag.keyword = keyword;
            }
            //Tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            //gửi số trang về view để hiển thị nav-trang
            ViewBag.pageNum = pageNum;
            //chọn dữ liệu trong trang hiện tại
            var result = learners.Skip(pageSize * (page - 1))
                            .Take(pageSize).Include(m => m.Major);
            return PartialView("LearnerTable", result);
        }

    }
}
