using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Trip;

public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, List<TripDto>>
{
	private readonly ITripRepository _tripRepository;
	private readonly IMapper _mapper;

	public GetAllTripsQueryHandler(ITripRepository tripRepository, IMapper mapper)
    {
		_tripRepository = tripRepository;
		_mapper = mapper;
	}
    public async Task<List<TripDto>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
	{
		var trips = await _tripRepository.GetAllTripsPaginated(20, 1);
		var results = _mapper.Map<List<TripDto>>(trips);
		return results;
	}
}
