using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainTicketsWebApp.Models;

namespace TrainTicketsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
