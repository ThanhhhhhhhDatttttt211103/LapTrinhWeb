using Microsoft.AspNetCore.Mvc;
using Ngay10_12_23_De210705.Models.Entities;

namespace Ngay10_12_23_De210705.ViewComponents
{
	public class FilterCateViewComponent : ViewComponent
	{
		private OnlineShopContext db;
		private List<Category> cateList;

		public FilterCateViewComponent(OnlineShopContext context)
		{
			db = context;
			cateList = db.Categories.ToList();
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderCate", cateList);
		}
	}
}
