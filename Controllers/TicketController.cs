using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsWebApp.CQRS.Queries.Ticket;
using TrainTicketsWebApp.Models.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainTicketsWebApp.Controllers
{
	public class TicketController : Controller
	{
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
		public async Task<IActionResult> Ticket(SearchReservationDto dto)
		{
            //var results = await _mediator.Send(new GetTicketsBySearchQuery(dto));
            return View(new List<ReservationDto>());
		}

		[HttpPost]
		public async Task<IActionResult> SearchReservation(SearchReservationDto data)
		{
			var results = await _mediator.Send(new GetTicketsBySearchQuery(data));
			//return RedirectToAction(nameof(Ticket), results);
			return View(nameof(Ticket), results);
		}
	}
}
