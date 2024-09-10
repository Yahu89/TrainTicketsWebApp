using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebApp.CQRS.Commands.Reservation;
using TrainTicketsWebApp.Database.Entities;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.Controllers
{
	public class TourController : Controller
	{
		private readonly ITripOccupationRepository _tripOccupationRepository;
		private readonly IMediator _mediator;

		public TourController(ITripOccupationRepository tripOccupationRepository, IMediator mediator)
        {
			_tripOccupationRepository = tripOccupationRepository;
			_mediator = mediator;
		}

        [HttpPost]
		public IActionResult Reservation(ReservationDto model)
		{
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ReservationConfirm(ReservationDto model)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View(nameof(Reservation), model);
			//}

			//int place = await _tripOccupationRepository.ReservePlace(model);
			await _mediator.Send(new ReservationCommand(model));
			return RedirectToAction("Index", "Home");
		}
	}
}
