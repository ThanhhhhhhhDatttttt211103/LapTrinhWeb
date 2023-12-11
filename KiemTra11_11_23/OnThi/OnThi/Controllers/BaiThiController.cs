using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnThi.Models.Entities;

namespace OnThi.Controllers
{
    public class BaiThiController : Controller
    {
        private NguyenThanhDat_Context db;

		public BaiThiController(NguyenThanhDat_Context context)
		{
			db = context;
		}
		private int pageSize = 4;
		public IActionResult Index()
        {
            List<HangHoa> hangHoas = db.HangHoas.Where(m => m.Gia >= 100).ToList();

			int pageNum = (int)Math.Ceiling(hangHoas.Count() / (float)pageSize);
			//trả số trnag về view ddeer hiển thị nav-trang
			ViewBag.pageNum = pageNum;
			//lấy dữ liệu trang đầu
			var result = hangHoas.Take(pageSize).ToList();
			//var result = hangHoas.ToList();
			ViewBag.listCate = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
			return View(result);
		}



        public IActionResult Create()
        {
			ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
			return View();
        }

		[HttpPost]
		public IActionResult Create(HangHoa hangHoa) {
			if (ModelState.IsValid)
			{
				db.HangHoas.Add(hangHoa);
				db.SaveChanges();
				return Redirect("Index");
			}
			else
			{
				ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
				return View();
			}
		}

		[HttpGet]
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
			if (ModelState.IsValid)
			{
				db.HangHoas.Update(hangHoa);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
				ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
				return View();
		}

		[HttpGet]
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


		public IActionResult HangHoaFilter(int? mid, string? keyword, int? pageIndex)
		{
			List<HangHoa> hangHoas = db.HangHoas.ToList();
			
			int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);

			if (mid != null)
			{
				hangHoas = hangHoas.Where(m => m.MaLoai == mid).ToList();
				ViewBag.mid = mid;
			}
			if(keyword != null)
			{
				hangHoas = hangHoas.Where(l => l.TenHang.ToLower()
										  .Contains(keyword.ToLower())).ToList();
				ViewBag.keyword = keyword;
			}

			int pageNum = (int)Math.Ceiling(hangHoas.Count() / (float)pageSize);
			//gửi số trang về view để hiển thị nav-trang
			ViewBag.pageNum = pageNum;
			//chọn dữ liệu trong trang hiện tại

			var result = hangHoas.Skip(pageSize * (page - 1))
							.Take(pageSize);
			return PartialView("HangHoaTable", result);
		}

		public IActionResult HangHoaBySelect(int? mid)
		{
			List<HangHoa> hangHoas = db.HangHoas.ToList();

			//int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);

			if (mid != null)
			{
				hangHoas = hangHoas.Where(m => m.MaLoai == mid).ToList();
				ViewBag.mid = mid;
			}
			return PartialView("HangHoaTable", hangHoas);
		}
	}
}
