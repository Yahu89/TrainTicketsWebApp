using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TrainTicketsWebApp.CQRS.Queries.Tour;
using TrainTicketsWebApp.Database.Collections;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;
using Newtonsoft.Json;

namespace TrainTicketsWebApp.Controllers
{
    public class ScheduleController : Controller
    {
		private readonly ITrainStationRepository _trainStationRepository;
		private readonly IMediator _mediator;
		private readonly IScheduleRepository _scheduleRepository;
		private readonly ITripOccupationRepository _tripOccupationRepository;

		public ScheduleController(ITrainStationRepository trainStationRepository, 
                                  IMediator mediator, 
                                  IScheduleRepository scheduleRepository,
                                  ITripOccupationRepository tripOccupationRepository)
        {
			_trainStationRepository = trainStationRepository;
			_mediator = mediator;
			_scheduleRepository = scheduleRepository;
			_tripOccupationRepository = tripOccupationRepository;
		}

        [HttpGet]
        public async Task<IActionResult> Search(SearchTourModelView model)
        {
			return View(await _mediator.Send(new GetToursFoundQuery(model)));
        }

        [HttpPost]
        public async Task<IActionResult> SearchTour(SearchTourModelView tour)
        {
            var result = await _mediator.Send(new GetToursFoundQuery(tour.SearchTourData));
            return View(nameof(Search), result);
        }

    }
}
