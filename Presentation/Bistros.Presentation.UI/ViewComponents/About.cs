using Microsoft.AspNetCore.Mvc;

namespace Bistros.Presentation.UI.ViewComponents
{
	public class About:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
