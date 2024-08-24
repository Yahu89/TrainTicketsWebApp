using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebApp.CQRS.Commands.Station;
using TrainTicketsWebApp.CQRS.Queries.Station;
using TrainTicketsWebApp.CQRS.Queries.TrainType;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddStation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStation(CreateTrainStationCommand dto)
        {
            if (!ModelState.IsValid)
            {
				return View(nameof(AddStation), dto);
			}

            try
            {
				await _mediator.Send(dto);
				return View(nameof(Stations), await _mediator.Send(new GetAllStationsQuery()));
			}
            catch (Exception ex)
            {
                ViewData["Error"] = "Dodanie stacji nie powiodło się...";
                return View("Error");
            }			
        }

        [HttpGet]
        public async Task<IActionResult> Stations()
        {
            var stations = await _mediator.Send(new GetAllStationsQuery());
            return View(stations);
        }

        public async Task<IActionResult> TrainTypes()
        {
            var result = await _mediator.Send(new GetAllTrainTypesQuery());
            return View(result);
        }

        [HttpGet]
        public IActionResult AddTrainType()
        {
            return View();
        }
    }
}
