using Microsoft.AspNetCore.Mvc;

namespace Bistros.Presentation.UI.ViewComponents
{
	public class Grids:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
