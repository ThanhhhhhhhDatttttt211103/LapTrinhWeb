using Microsoft.AspNetCore.Mvc;
using TongOn.Models.Entities;

namespace TongOn.ViewComponents
{
	public class FilterCateViewComponent : ViewComponent
	{
		private OnlineShopContext db;
		private List<Category> categories;

		public FilterCateViewComponent(OnlineShopContext context)
		{
			db = context;
			categories = db.Categories.ToList();
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderCate", categories);
		}
	}
}
