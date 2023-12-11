using Microsoft.AspNetCore.Mvc;
using NguyenThanhDat_211201056.Models.Entities;

namespace NguyenThanhDat_211201056.ViewComponents
{
	public class LoaiHangViewComponent : ViewComponent
	{
		private NguyenThanhDat_Context db;
		List<LoaiHang> loaiHangs;
		public LoaiHangViewComponent(NguyenThanhDat_Context context)
		{
			db = context;
			loaiHangs = db.LoaiHangs.ToList();
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderLoaiHang", loaiHangs);
		}
	}
}
