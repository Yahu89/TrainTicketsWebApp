using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Commands.Trip;

public class CreateTripsCommandHandler : IRequestHandler<CreateTripsCommand>
{
	private readonly ITripRepository _tripRepository;
	private readonly IMapper _mapper;
	private readonly IScheduleRepository _scheduleRepository;

	public CreateTripsCommandHandler(ITripRepository tripRepository, 
									IMapper mapper, 
									IScheduleRepository scheduleRepository)
    {
		_tripRepository = tripRepository;
		_mapper = mapper;
		_scheduleRepository = scheduleRepository;
	}
    public async Task<Unit> Handle(CreateTripsCommand request, CancellationToken cancellationToken)
	{
		var list = request.trips.Select(x => new Database.Entities.Trip()
		{
			RouteId = x.RouteId,
			DepartureTime = DateTime.Parse($"{x.DepartureDate} {x.DepartureTime}"),
			TrainTypeName = x.TrainType,
		}).ToList();

		var idList = await _tripRepository.CreateRange(list);

		var schedules = await _scheduleRepository.GenerateSchedules(list);
		await _scheduleRepository.CreateRange(schedules);

		return Unit.Value;
	}
}
