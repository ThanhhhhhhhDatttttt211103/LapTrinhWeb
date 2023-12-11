using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TongOn.Models.Entities;

namespace TongOn.Controllers
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
			var hangHoas = db.Products.Where(m=> m.Available == true).ToList();
			return View(hangHoas);
		}


		public IActionResult HangHoaFilter(int mid)
		{
			var hangHoas = db.Products.Where(m => m.Available == true).ToList();
			if(mid != null)
			{
				hangHoas = db.Products.Where(m => m.Available == true && m.CategoryId == mid).ToList();
			}
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
			if (ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
			return View();
		}

		[HttpGet]
		public IActionResult Edit(string id)
		{
			Product hangHoa = db.Products.Find(id);
			if (hangHoa != null)
			{
				ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
				return View(hangHoa);
			}
			return View();
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if(ModelState.IsValid)
			{
				db.Products.Update(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
			return View();
		}

		[HttpGet]
		public IActionResult Delete(string id)
		{
			Product hangHoa = db.Products.Find(id);
			if (hangHoa != null)
			{
				return View(hangHoa);
			}
			return View();
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(string id)
		{
			Product hangHoa = db.Products.Find(id);
			if (hangHoa != null)
			{
				db.Products.Remove(hangHoa);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(hangHoa);
		}

	}
}
