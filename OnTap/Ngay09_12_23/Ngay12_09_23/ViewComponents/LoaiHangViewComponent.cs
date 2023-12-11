using Microsoft.AspNetCore.Mvc;
using Ngay12_09_23.Models.Entities;

namespace Ngay12_09_23.ViewComponents
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
