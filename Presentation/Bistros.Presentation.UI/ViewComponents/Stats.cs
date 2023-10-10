using Microsoft.AspNetCore.Mvc;

namespace Bistros.Presentation.UI.ViewComponents
{
	public class Stats:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
