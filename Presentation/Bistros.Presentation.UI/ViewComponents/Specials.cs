using Microsoft.AspNetCore.Mvc;

namespace Bistros.Presentation.UI.ViewComponents
{
	public class Specials:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
