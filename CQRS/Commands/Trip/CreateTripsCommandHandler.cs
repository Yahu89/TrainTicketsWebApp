using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Database.Collections;
using TrainTicketsWebApp.Repositories.Interface;
using TrainTicketsWebApp.Repositories.Repository;

namespace TrainTicketsWebApp.CQRS.Commands.Trip;

public class CreateTripsCommandHandler : IRequestHandler<CreateTripsCommand>
{
	private readonly ITripRepository _tripRepository;
	private readonly IMapper _mapper;
	private readonly IScheduleRepository _scheduleRepository;
	private readonly ITripOccupationRepository _tripOccupationRepository;

	public CreateTripsCommandHandler(ITripRepository tripRepository, 
									IMapper mapper, 
									IScheduleRepository scheduleRepository,
									ITripOccupationRepository tripOccupationRepository)
    {
		_tripRepository = tripRepository;
		_mapper = mapper;
		_scheduleRepository = scheduleRepository;
		_tripOccupationRepository = tripOccupationRepository;
	}
    public async Task<Unit> Handle(CreateTripsCommand request, CancellationToken cancellationToken)
	{
		var list = request.trips.Select(x => new Database.Entities.Trip()
		{
			RouteId = x.RouteId,
			DepartureTime = DateTime.Parse($"{x.DepartureDate} {x.DepartureTime}"),
			TrainTypeName = x.TrainType,
		}).ToList();

		var tripIdList = await _tripRepository.CreateRange(list);

		var schedules = await _scheduleRepository.GenerateSchedules(list);
		await _scheduleRepository.CreateRange(schedules);

		foreach (var trip in tripIdList)
		{
			await _tripOccupationRepository.CreateTripOccupation(new TripOccupation(trip.Id.ToString(), trip.Route.RouteDetails.Count, trip.TrainType.TotalPlacesAvailable));
		}

		return Unit.Value;
	}
}
