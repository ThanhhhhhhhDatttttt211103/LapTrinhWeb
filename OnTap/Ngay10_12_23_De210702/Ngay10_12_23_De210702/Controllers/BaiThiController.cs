using Microsoft.AspNetCore.Mvc;
using Ngay10_12_23_De210702.Models.Entities;

namespace Ngay10_12_23_De210702.Controllers
{
	public class BaiThiController : Controller
	{
		private NguyenThanhDat_Context db;

		public BaiThiController(NguyenThanhDat_Context context)
		{
			db = context;
		}
		public IActionResult Index()
		{
			var hangHoas = db.Products.Take(4).OrderBy(m => m.UnitPrice).ToList();
			return View(hangHoas);
		}


		public IActionResult HangHoaByFilter(string keyword)
		{
			Console.WriteLine("Đã vào trong");
			var hangHoas = db.Products.Where(l => l.Name.ToLower()
										  .Contains(keyword.ToLower())).ToList();
			return PartialView("HangHoaTable", hangHoas);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Customer cus)
		{
			if (ModelState.IsValid)
			{
				db.Customers.Add(cus);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
