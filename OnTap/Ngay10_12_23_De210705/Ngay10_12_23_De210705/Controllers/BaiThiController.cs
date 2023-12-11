using Microsoft.AspNetCore.Mvc;
using Ngay10_12_23_De210705.Models.Entities;

namespace Ngay10_12_23_De210705.Controllers
{
	public class BaiThiController : Controller
	{
		private OnlineShopContext db;
		private int pageSize = 4;
		public BaiThiController(OnlineShopContext context)
		{
			db = context;
		}
		public IActionResult Index()
		{
			var hangHoas = db.Products.Where(m => m.Available == true).ToList();
			int pageNum = (int)Math.Ceiling(hangHoas.Count() / (float)pageSize);
			ViewBag.pageNum = pageNum;
			var result = hangHoas.Take(pageSize).ToList();

			return View(result);
		}

		public IActionResult HangHoaByFilter(int? mid)
		{
			var hangHoas = db.Products.ToList();
			if(mid != null)
			{
				hangHoas = db.Products.Where(m => m.CategoryId == mid).ToList();
			}
			return PartialView("HangHoaTable", hangHoas);
		}

		public IActionResult PhanTrang(int pageIndex)
		{
			var hangHoas = db.Products.Where(m => m.Available == true).ToList();

			int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
			int pageNum = (int)Math.Ceiling(hangHoas.Count() / (float)pageSize);
			//gửi số trang về view để hiển thị nav-trang
			ViewBag.pageNum = pageNum;
			//chọn dữ liệu trong trang hiện tại

			var result = hangHoas.Skip(pageSize * (page - 1))
							.Take(pageSize);
			return PartialView("HangHoaTable", result);
		}
	}

}
