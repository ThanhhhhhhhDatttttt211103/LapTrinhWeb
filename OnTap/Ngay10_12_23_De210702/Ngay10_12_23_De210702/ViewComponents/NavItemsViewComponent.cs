using Microsoft.AspNetCore.Mvc;
using Ngay10_12_23_De210702.Models.Entities;

namespace Ngay10_12_23_De210702.ViewComponents
{
	public class NavItemsViewComponent :ViewComponent
    {
		private NguyenThanhDat_Context db;
		List<NavItem> navItems;

		public NavItemsViewComponent(NguyenThanhDat_Context context)
		{
			db = context;
			navItems = db.NavItems.ToList();	
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderNavItems", navItems);
		}
	}
}
