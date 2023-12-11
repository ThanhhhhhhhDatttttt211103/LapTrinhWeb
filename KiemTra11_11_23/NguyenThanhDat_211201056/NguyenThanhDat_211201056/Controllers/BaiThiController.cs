using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenThanhDat_211201056.Models.Entities;
using System.Security.Cryptography;

namespace NguyenThanhDat_211201056.Controllers
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
			ViewBag.List = db.LoaiHangs.ToList();

            List<HangHoa> listHangHoa = db.HangHoas.Where(h => h.Gia >= 100).ToList();

			return View(listHangHoa);


        }

        //public IActionResult RenderNav ()
        //{
        //    List<LoaiHang> listLoai = db.LoaiHangs.ToList();
        //    ViewBag.List = listLoai;
        //    return PartialView("NguyenThanhDat_Header", listLoai);
        //}


        public IActionResult Create () {
			ViewBag.List = db.LoaiHangs.ToList();
			ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
			return View(); 
        }

        [HttpPost]
        public IActionResult Create(HangHoa hang)
        {
                db.HangHoas.Add(hang);
			    db.SaveChanges();
			    return Redirect("Index");
        }

        public IActionResult LoaiHangByMaLoai(int mid)
        {         
            var hangHoas = db.HangHoas
                .Where(l => l.MaLoai == mid).ToList();
            return PartialView("LoaiHangTable", hangHoas);
        }
    }
}
