using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Trip;

public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, TripsPaginationResultView>
{
	private readonly ITripRepository _tripRepository;
	private readonly IMapper _mapper;

	public GetAllTripsQueryHandler(ITripRepository tripRepository, IMapper mapper)
    {
		_tripRepository = tripRepository;
		_mapper = mapper;
	}

    public async Task<TripsPaginationResultView> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
    {
        var trips = await _tripRepository.GetAllTripsPaginated(3, request.CurrentPageNumber);
        var tripsDto = _mapper.Map<List<TripDto>>(trips);
        var totalRecords = await _tripRepository.AllTripsQty();

        int totalPages = (int)Math.Ceiling(totalRecords / (double)3);

        TripsPaginationResultView view = new TripsPaginationResultView(tripsDto)
        {
            Trips = tripsDto,
            TotalPages = totalPages,
            CurrentPageNumber = request.CurrentPageNumber,
        };

        return view;
    }
}
