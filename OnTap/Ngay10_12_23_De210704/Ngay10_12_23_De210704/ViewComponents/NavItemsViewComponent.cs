using Microsoft.AspNetCore.Mvc;
using Ngay10_12_23_De210704.Models.Entities;

namespace Ngay10_12_23_De210704.ViewComponents
{
	public class NavItemsViewComponent : ViewComponent
	{
		private OnlineShopContext db;
		private List<NavItem> navItems;

		public NavItemsViewComponent(OnlineShopContext context)
		{
			db = context;
			navItems = db.NavItems.ToList();
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderNav", navItems);
		}
	}
}
