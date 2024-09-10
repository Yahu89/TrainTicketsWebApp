using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Repositories.Interface;
using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.CQRS.Commands.Reservation;

public class ReservationCommandHandler : IRequestHandler<ReservationCommand>
{
	private readonly ITourRepository _tourRepository;
	private readonly ITripOccupationRepository _tripOccupationRepository;
	private readonly IMapper _mapper;

	public ReservationCommandHandler(ITourRepository tourRepository, 
									ITripOccupationRepository tripOccupationRepository,
									IMapper mapper)
    {
		_tourRepository = tourRepository;
		_tripOccupationRepository = tripOccupationRepository;
		_mapper = mapper;
	}
    public async Task<Unit> Handle(ReservationCommand request, CancellationToken cancellationToken)
	{
		try
		{
			int place = await _tripOccupationRepository.ReservePlace(request);
			request.SeatNumber = place;
			var result = _mapper.Map<Database.Entities.Reservation>(request);
			await _tourRepository.CreateReservation(result);		
		}
		catch (Exception ex)
		{
			throw;
		}

		return Unit.Value;
	}
}
