using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebApp.CQRS.Commands.Route;
using TrainTicketsWebApp.CQRS.Commands.RouteDetails;
using TrainTicketsWebApp.CQRS.Commands.Station;
using TrainTicketsWebApp.CQRS.Commands.TrainType;
using TrainTicketsWebApp.CQRS.Commands.Trip;
using TrainTicketsWebApp.CQRS.Queries.Route;
using TrainTicketsWebApp.CQRS.Queries.RouteDetails;
using TrainTicketsWebApp.CQRS.Queries.Station;
using TrainTicketsWebApp.CQRS.Queries.TrainType;
using TrainTicketsWebApp.CQRS.Queries.Trip;
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

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> CreateTrainType(CreateTrainTypeCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(AddTrainType), command);
            }

            try
            {
                await _mediator.Send(command);
                return View(nameof(TrainTypes), await _mediator.Send(new GetAllTrainTypesQuery()));
            }
            catch (Exception ex)
            {
				ViewData["Error"] = "Dodanie rodzaju pociągu nie powiodło się...";
				return View("Error");
			}
        }

        [HttpGet]
        public async Task<IActionResult> Routes()
        {
            var results = await _mediator.Send(new GetAllRoutesQuery());
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> AddRoute()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(AddRoute), command);
            }

            try
            {
                await _mediator.Send(command);
                return View(nameof(Routes), await _mediator.Send(new GetAllRoutesQuery()));
            }
            catch(Exception ex)
            {
				ViewData["Error"] = "Dodanie trasy nie powiodło się...";
				return View("Error");
			}
        }

        [HttpGet]
        public async Task<IActionResult> AddRouteDetails()
        {
            var result = await _mediator.Send(new RouteDetailsCreationViewQuery());
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRouteDetails([FromBody]List<CreateRouteDetailsDto> model)
        {
            try
            {
                CreateRouteDetailsCommand command = new CreateRouteDetailsCommand(model);
                await _mediator.Send(command);
				return Json(new { redirectToUrl = Url.Action(nameof(Index), "Admin") });
			}
            catch (Exception ex)
            {
				ViewData["Error"] = "Konfiguracja trasy nie powiodła się...";
				return Json(new { redirectToUrlError = Url.Action("Error", "Home") });
			}

        }

        [HttpGet]
        public async Task<IActionResult> AddTrips()
        {
            var results = await _mediator.Send(new GetAllTripsCreationViewQuery());
            return View(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrips([FromBody]List<CreateTripsDto> dto)
        {
            try
            {
                CreateTripsCommand command = new CreateTripsCommand(dto);
                await _mediator.Send(command);
				return Json(new { redirectToUrl = Url.Action(nameof(Index), "Admin") });
			}
            catch (Exception ex)
            {
				ViewData["Error"] = "Dodanie przejazdu nie powiodło się...";
				return Json(new { redirectToUrl = Url.Action("Error", "Home") });
			}
        }

        [HttpGet]
        public async Task<IActionResult> RouteDetail(string routeName)
        {
            return View(await _mediator.Send(new GetRouteDetailQuery(routeName)));
        }

        [HttpGet]
        public async Task<IActionResult> Trips(int currentPageNumber = 1)
        {
            var result = await _mediator.Send(new GetAllTripsQuery(currentPageNumber: currentPageNumber));
            return View(result);
        }

    }
}
