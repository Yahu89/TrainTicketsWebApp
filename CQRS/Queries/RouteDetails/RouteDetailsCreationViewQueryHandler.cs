using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.RouteDetails;

public class RouteDetailsCreationViewQueryHandler : IRequestHandler<RouteDetailsCreationViewQuery, RouteDetailsCreationView>
{
	private readonly ITrainStationRepository _trainStationRepository;

	public RouteDetailsCreationViewQueryHandler(ITrainStationRepository trainStationRepository)
    {
		_trainStationRepository = trainStationRepository;
	}
    public async Task<RouteDetailsCreationView> Handle(RouteDetailsCreationViewQuery request, CancellationToken cancellationToken)
	{
		var result = await _trainStationRepository.GetRouteDetailsCreationView();
		return result;
	}
}
