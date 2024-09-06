using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Tour;

public class SearchingTourViewQueryHandler : IRequestHandler<SearchingTourViewQuery, RouteDetailsCreationView>
{
	private readonly ITrainStationRepository _trainStationRepository;
	public SearchingTourViewQueryHandler(ITrainStationRepository trainStationRepository)
    {
		_trainStationRepository = trainStationRepository;
	}
    public async Task<RouteDetailsCreationView> Handle(SearchingTourViewQuery request, CancellationToken cancellationToken)
	{
		var result = await _trainStationRepository.GetRouteDetailsCreationView();
		return result;
	}
}
