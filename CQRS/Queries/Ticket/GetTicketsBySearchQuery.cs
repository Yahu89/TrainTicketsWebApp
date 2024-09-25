using MediatR;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.CQRS.Queries.Ticket;

public class GetTicketsBySearchQuery : IRequest<List<ReservationDto>>
{
    public SearchReservationDto SearchReservation { get; set; }
    public GetTicketsBySearchQuery(SearchReservationDto dto)
    {
        SearchReservation = dto;
    }
}
