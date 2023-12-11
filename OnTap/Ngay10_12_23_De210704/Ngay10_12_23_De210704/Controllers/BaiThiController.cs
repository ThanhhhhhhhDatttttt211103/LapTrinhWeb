using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ngay10_12_23_De210704.Models.Entities;

namespace Ngay10_12_23_De210704.Controllers
{
	public class BaiThiController : Controller
	{
		private OnlineShopContext db;

		public BaiThiController(OnlineShopContext context)
		{
			db = context;
		}
		public IActionResult Index()
		{
			var hangHoas = db.Products.Take(3).OrderByDescending(m => m.UnitPrice).ToList();
			return View(hangHoas);
		}

		public IActionResult HangHoaByFilter(string keyword) {
			var hangHoas = db.Products.Where(l => l.Name.ToLower()
										  .Contains(keyword.ToLower())).ToList();
			return PartialView("HangHoaTable", hangHoas);

		}
		public IActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			if(ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
			return View();
		}
	}
}
