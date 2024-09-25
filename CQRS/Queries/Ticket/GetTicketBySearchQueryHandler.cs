using AutoMapper;
using MediatR;
using TrainTicketsWebApp.Models.Dto;
using TrainTicketsWebApp.Repositories.Interface;

namespace TrainTicketsWebApp.CQRS.Queries.Ticket;

public class GetTicketBySearchQueryHandler : IRequestHandler<GetTicketsBySearchQuery, List<ReservationDto>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public GetTicketBySearchQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }
    public async Task<List<ReservationDto>> Handle(GetTicketsBySearchQuery request, CancellationToken cancellationToken)
    {
        var results = _mapper.Map<List<ReservationDto>>(await _ticketRepository.GetReservationsBySearch(request.SearchReservation));
        return results;
    }
}
