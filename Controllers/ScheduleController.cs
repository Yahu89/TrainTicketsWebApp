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
        public async Task<IActionResult> Search()
        {
            return View(await _mediator.Send(new SearchingTourViewQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> SearchTour(GetToursFoundQuery tour)
        {
            var result = await _mediator.Send(tour);
            return View(result);
        }

        public async Task<IActionResult> CreateTripMongo()
        {
            //TripOccupation dto = new TripOccupation(10, 10)
            //{
            //    TripId = "46",
            //};

            //BsonDocument doc = new BsonDocument()
            //{
            //    { "Name", "Krzychu" },
            //    { "LastName", "Yahu" }
            //};

            //await _tripOccupationRepository.CreateDocument(doc);

            //await _tripOccupationRepository.CreateTripOccupation(dto);
            return Json("Success");
        }
    }
}
