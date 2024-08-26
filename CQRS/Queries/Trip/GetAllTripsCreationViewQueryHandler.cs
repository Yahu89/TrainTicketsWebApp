using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Trip;

public class GetAllTripsCreationViewQueryHandler : IRequestHandler<GetAllTripsCreationViewQuery, TripCreationView>
{
	private readonly ITripRepository _tripRepository;

	public GetAllTripsCreationViewQueryHandler(ITripRepository tripRepository)
    {
		_tripRepository = tripRepository;
	}

	public async Task<TripCreationView> Handle(GetAllTripsCreationViewQuery request, CancellationToken cancellationToken)
	{
		var result = await _tripRepository.GetTripCreationView();
		return result;
	}
}
