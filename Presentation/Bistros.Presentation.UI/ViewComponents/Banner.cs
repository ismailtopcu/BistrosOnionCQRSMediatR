using Microsoft.AspNetCore.Mvc;

namespace Bistros.Presentation.UI.ViewComponents
{
	public class Banner:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
