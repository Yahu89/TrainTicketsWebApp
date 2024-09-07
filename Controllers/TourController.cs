using Microsoft.AspNetCore.Mvc;

namespace TrainTicketsWebApp.Controllers
{
	public class TourController : Controller
	{
		public IActionResult Reservation()
		{
			return View();
		}
	}
}
