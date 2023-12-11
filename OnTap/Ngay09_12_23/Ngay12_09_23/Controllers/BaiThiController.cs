using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ngay12_09_23.Models.Entities;

namespace Ngay12_09_23.Controllers
{
    public class BaiThiController : Controller
    {
        NguyenThanhDat_Context db;

        public BaiThiController(NguyenThanhDat_Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var listHangs = db.HangHoas.Where(m => m.Gia >= 100).ToList();
            return View(listHangs);
        }

        public IActionResult HangHoaByFilter(int mid) {
            var hangHoas = db.HangHoas.Where(m => m.MaLoai == mid).ToList();
			return PartialView("HangHoaTable", hangHoas);
		}

        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
		public IActionResult Create(HangHoa hangHoa)
		{
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return Redirect("Index");

            }
			ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
			return View();
		}

        public IActionResult Edit(int id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            if(hangHoa != null) 
            {
				ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
				return View(hangHoa);
			}
            return View();
        }

        [HttpPost]
        public IActionResult Edit(HangHoa hangHoa)
        {
            if(ModelState.IsValid)
            {
                db.HangHoas.Update(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
			return View();
		}

        public IActionResult Delete(int id)
        {
			HangHoa hangHoa = db.HangHoas.Find(id);
			if (hangHoa != null)
			{
				return View(hangHoa);
			}
			return View();
		}

        [HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			HangHoa hangHoa = db.HangHoas.Find(id);
			if (hangHoa != null)
			{
				db.HangHoas.Remove(hangHoa);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(hangHoa);
		}
	}
}
