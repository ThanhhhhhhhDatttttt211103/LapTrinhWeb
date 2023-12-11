using Microsoft.AspNetCore.Mvc;
using OnThi.Models.Entities;

namespace OnThi.ViewComponents
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
