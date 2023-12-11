using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;
using NguyenThanhDat_211201056.Models.Entities;

namespace NguyenThanhDat_211201056.Controllers
{
    public class BaiThiController : Controller
    {
        private NewShopContext db;
        public BaiThiController(NewShopContext context)
        {
            db = context;
        }
		public IActionResult Index()
        {
            var sanPhams = db.Products.Take(6).OrderByDescending(m => m.ProviderId).ToList();
            return View(sanPhams);
        }

        public IActionResult SanPhamFilter(string? keyword)
        {
            var sanPhams = db.Products.Take(6).OrderByDescending(m => m.ProviderId).ToList();
            if(keyword != null)
            {
                sanPhams = db.Products.Where(l => l.Name.ToLower()
                                          .Contains(keyword.ToLower())).ToList();
            }        
			return PartialView("SanPhamTable", sanPhams);
        }

        public IActionResult Edit(string id)
        {
            var sanPham = db.Products.Find(id);
            if(sanPham != null)
            {
                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
                ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ProviderName");
                return View(sanPham);
			}
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product sanPham) {
            if (ModelState.IsValid)
            {
                db.Products.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
			ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ProviderName");
			return View();
		}
    }
}
