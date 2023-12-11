using Microsoft.AspNetCore.Mvc;
using Ngay10_12_23_De210703.Models.Entities;

namespace Ngay10_12_23_De210703.ViewComponents
{
	public class CategoriesViewComponent :ViewComponent
	{
		private OnlineShopContext db;
		private List<Category> cateList;

		public CategoriesViewComponent(OnlineShopContext context)
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
